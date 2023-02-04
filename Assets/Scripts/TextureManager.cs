using System;
using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    sealed class TextureManager : MonoBehaviour {
        public static TextureManager instance { get; private set; }

        [SerializeField]
        Rect playSpace = new();

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

        [SerializeField, Expandable]
        Texture2D m_collisionTexture;
        public Texture2D collisionTexture => m_collisionTexture;

        void Awake() {
            instance = this;
        }

        void OnEnable() {
            GameManager.onPreMoveRoots += PreMoveRoots;
            GameManager.onPostMoveRoots += PostMoveRoots;
        }

        void OnDisable() {
            GameManager.onPreMoveRoots -= PreMoveRoots;
            GameManager.onPostMoveRoots -= PostMoveRoots;
        }

        void Start() {
            m_collisionTexture = new Texture2D(targetTexture.width, targetTexture.height, renderFormat, false) {
                name = "Playfield",
                filterMode = FilterMode.Point,
                wrapMode = TextureWrapMode.Clamp,
                anisoLevel = 0,
            };
            renderRect = new Rect(0, 0, targetTexture.width, targetTexture.height);
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

        Vector2 WorldSpaceToRenderTextureSpace(in Vector3 position) {
            var normalizedPosition = position.SwizzleXY();

            normalizedPosition += playSpace.position;

            normalizedPosition /= playSpace.size;

            return normalizedPosition;
        }
        Vector2Int WorldSpaceToTexture2DSpace(in Vector3 position) {
            var normalizedPosition = WorldSpaceToRenderTextureSpace(position);

            return Vector2Int.RoundToInt(Vector2.Scale(normalizedPosition, renderRect.size));
        }

        public void DrawPixelWorldSpace(in Color color, in Vector3 worldPosition) {
            GL.PushMatrix();
            renderMaterial.SetPass(0);
            GL.LoadOrtho();

            GL.Color(color);
            GL.Begin(GL.LINES);
            var position = WorldSpaceToRenderTextureSpace(worldPosition);
            GL.Vertex3(position.x, position.y, 0);
            GL.Vertex3(position.x, position.y, 0);
            GL.End();

            GL.PopMatrix();
        }

        public void DrawLineWorldSpace(in Color color, in Vector3 worldStartPosition, in Vector3 worldTargetPosition) {
            var startPosition = WorldSpaceToRenderTextureSpace(worldStartPosition);
            var targetPosition = WorldSpaceToRenderTextureSpace(worldTargetPosition);

            GL.Color(color);
            GL.Vertex3(startPosition.x, startPosition.y, 0);
            GL.Vertex3(targetPosition.x, targetPosition.y, 0);
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
                if (x0 == x1 && y0 == y1) {
                    break;
                }

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
            }

            return true;
        }
    }
}
