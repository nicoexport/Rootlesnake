using System;
using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    sealed class TextureManager : MonoBehaviour {
        public static TextureManager instance { get; private set; }

        [SerializeField]
        Vector2Int m_playSpaceSize = new(192, 81);
        public Vector2Int playSpaceSize => m_playSpaceSize;

        [SerializeField, Expandable]
        RenderTexture targetTexture;
        [SerializeField, ReadOnly]
        RenderTexture previousTexture;
        [SerializeField]
        TextureFormat renderFormat = TextureFormat.RGBA32;
        [SerializeField, Expandable]
        Material renderMaterial = default;
        [SerializeField, ReadOnly]
        Rect renderRect = new();
        [SerializeField, ReadOnly]
        Vector3 renderTexturePixelSize = new();

        [SerializeField, Expandable]
        Texture2D m_collisionTexture;
        public Texture2D collisionTexture => m_collisionTexture;

        void Awake() {
            instance = this;

            m_collisionTexture = new Texture2D(targetTexture.width, targetTexture.height, renderFormat, false) {
                name = "Playfield",
                filterMode = FilterMode.Point,
                wrapMode = TextureWrapMode.Clamp,
                anisoLevel = 0,
            };
            renderRect = new Rect(0, 0, targetTexture.width, targetTexture.height);
            renderTexturePixelSize = new(1f / renderRect.width, 1f / renderRect.height, 0);
        }

        void OnEnable() {
            GameManager.onPreMoveRoots += PreMoveRoots;
            GameManager.onPostMoveRoots += PostMoveRoots;
        }

        void OnDisable() {
            GameManager.onPreMoveRoots -= PreMoveRoots;
            GameManager.onPostMoveRoots -= PostMoveRoots;
        }

        void OnDestroy() {
            if (m_collisionTexture) {
                Destroy(m_collisionTexture);
            }
        }

        void PreMoveRoots() {
            previousTexture = RenderTexture.active;
            RenderTexture.active = targetTexture;
            m_collisionTexture.ReadPixels(renderRect, 0, 0);
            m_collisionTexture.Apply();

            GL.PushMatrix();
            renderMaterial.SetPass(0);
            GL.LoadOrtho();

            GL.Begin(GL.LINES);
        }

        Vector3 WorldSpaceToRenderTextureSpace(in Vector3 position) {
            var normalizedPosition = position.SwizzleXY();

            normalizedPosition /= playSpaceSize;

            return normalizedPosition;
        }
        Vector2Int WorldSpaceToTexture2DSpace(in Vector3 position) {
            var normalizedPosition = WorldSpaceToRenderTextureSpace(position);

            return Vector2Int.RoundToInt(Vector2.Scale(normalizedPosition, renderRect.size));
        }

        public void DrawPixelWorldSpace(in Color color, in Vector3 worldPosition) {
            var previousTexture = RenderTexture.active;
            RenderTexture.active = targetTexture;

            GL.PushMatrix();
            renderMaterial.SetPass(0);
            GL.LoadOrtho();

            GL.Begin(GL.QUADS);
            GL.Color(color);
            var position = WorldSpaceToRenderTextureSpace(worldPosition);
            GL.Vertex(position);
            GL.Vertex(position + renderTexturePixelSize.WithY(0));
            GL.Vertex(position + renderTexturePixelSize);
            GL.Vertex(position + renderTexturePixelSize.WithX(0));
            GL.End();

            GL.PopMatrix();

            RenderTexture.active = previousTexture;
        }

        public void DrawLineWorldSpace(in Color color, in Vector3 worldStartPosition, in Vector3 worldTargetPosition) {
            var startPosition = WorldSpaceToRenderTextureSpace(worldStartPosition);
            var targetPosition = WorldSpaceToRenderTextureSpace(worldTargetPosition);

            GL.Color(color);
            GL.Vertex(startPosition);
            GL.Vertex(targetPosition);
        }

        void PostMoveRoots() {
            GL.End();

            GL.PopMatrix();

            RenderTexture.active = previousTexture;
        }

        public bool CheckIfMoveIsPossible(in Vector3 worldStartPosition, in Vector3 worldMotion) {
            //get all Pixels inbetween the currentPosition and the position after moving
            var worldTargetPosition = worldStartPosition + worldMotion;

            var startPosition = WorldSpaceToTexture2DSpace(worldStartPosition);
            var targetPosition = WorldSpaceToTexture2DSpace(worldTargetPosition);

            if (IsOutOfBounds(targetPosition)) {
                return false;
            }

            if (startPosition == targetPosition) {
                return true;
            }

            int x0 = startPosition.x;
            int y0 = startPosition.y;

            int x1 = targetPosition.x;
            int y1 = targetPosition.y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true) {

                int e2 = 2 * err;
                if (e2 > -dy) {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx) {
                    err += dx;
                    y0 += sy;
                }

                if (m_collisionTexture.GetPixel(x0, y0).a > 0.5f) {
                    return false;
                }

                if (x0 == x1 && y0 == y1) {
                    break;
                }
            }
            return true;
        }

        public bool IsOutOfBounds(Vector2Int position) {

            if (position.x < 0 || position.x > m_collisionTexture.width) {
                return true;
            }
            if (position.y < 0 || position.y > m_collisionTexture.height) {
                return true;
            }

            return false;
        }
    }
}
