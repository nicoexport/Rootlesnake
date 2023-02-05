using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    sealed class TextureManager : MonoBehaviour {
        public static TextureManager instance { get; private set; }

        [SerializeField]
        Vector2Int m_playfieldSize = new(192, 81);
        public Vector2Int playfieldSize => m_playfieldSize;
        [SerializeField]
        Vector2Int m_renderSize = new(960, 405);
        public Vector2Int renderSize => m_renderSize;
        [SerializeField]
        TextureFormat renderFormat = TextureFormat.RGBA32;

        [SerializeField, Expandable]
        Texture2D m_collisionTexture;
        public Texture2D collisionTexture => m_collisionTexture;

        void Awake() {
            instance = this;

            m_collisionTexture = new Texture2D(m_renderSize.x, m_renderSize.y, renderFormat, false) {
                name = "Playfield",
                filterMode = FilterMode.Point,
                wrapMode = TextureWrapMode.Clamp,
                anisoLevel = 0,
            };
            m_collisionTexture.SetPixels(Enumerable.Repeat(new Color(0, 0, 0, 0), renderSize.x * renderSize.y).ToArray());
            m_collisionTexture.Apply();
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
            /*
            previousTexture = RenderTexture.active;
            RenderTexture.active = targetTexture;
            m_collisionTexture.ReadPixels(renderRect, 0, 0);
            m_collisionTexture.Apply();

            GL.PushMatrix();
            renderMaterial.SetPass(0);
            GL.LoadOrtho();

            GL.Begin(GL.LINES);
            //*/
        }

        Vector3 WorldSpaceToRenderTextureSpace(in Vector3 position) {
            var normalizedPosition = position.SwizzleXY();

            normalizedPosition.x += playfieldSize.x * 0.5f;
            normalizedPosition.y += playfieldSize.y * 0.5f;
            normalizedPosition /= playfieldSize;

            return normalizedPosition;
        }
        public Vector2Int WorldSpaceToPixelSpace(in Vector3 position) {
            var normalizedPosition = WorldSpaceToRenderTextureSpace(position);

            normalizedPosition.x *= renderSize.x;
            normalizedPosition.y *= renderSize.y;

            return Vector2Int.RoundToInt(normalizedPosition);
        }

        public void DrawDotPixelSpace(in Color color, in Vector2Int position) {
            collisionTexture.SetPixel(position.x, position.y, color);
        }

        void DrawDotWorldSpace(in Color color, in Vector3 worldPosition) {
            DrawDotPixelSpace(color, WorldSpaceToPixelSpace(worldPosition));

            /*
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
            //*/
        }

        public void DrawLinePixelSpace(in Color color, in Vector2Int startPosition, in Vector2Int targetPosition) {
            collisionTexture.SetPixel(startPosition.x, startPosition.y, color);
            if (startPosition != targetPosition) {
                collisionTexture.SetPixel(targetPosition.x, targetPosition.y, color);
            }
        }

        void DrawLineWorldSpace(in Color color, in Vector3 worldStartPosition, in Vector3 worldTargetPosition) {
            DrawLinePixelSpace(color, WorldSpaceToPixelSpace(worldStartPosition), WorldSpaceToPixelSpace(worldTargetPosition));
            /*
            var startPosition = WorldSpaceToRenderTextureSpace(worldStartPosition);
            var targetPosition = WorldSpaceToRenderTextureSpace(worldTargetPosition);

            GL.Color(color);
            GL.Vertex(startPosition);
            GL.Vertex(targetPosition);
            //*/
        }

        void PostMoveRoots() {
            m_collisionTexture.Apply();

            /*
            GL.End();

            GL.PopMatrix();

            RenderTexture.active = previousTexture;
            //*/
        }

        public bool TryToHitSomething(in Vector3 worldStartPosition, in Vector3 worldMotion, out Color hitColor) {
            //get all Pixels inbetween the currentPosition and the position after movin
            hitColor = Color.black;

            var worldTargetPosition = worldStartPosition + worldMotion;

            var startPosition = WorldSpaceToPixelSpace(worldStartPosition);
            var targetPosition = WorldSpaceToPixelSpace(worldTargetPosition);

            if (IsOutOfBounds(targetPosition)) {
                return true;
            }

            if (startPosition == targetPosition) {
                return false;
            }

            var delta = worldTargetPosition - worldStartPosition;

            int steps = Mathf.CeilToInt(Mathf.Abs(Mathf.Abs(delta.x) > Mathf.Abs(delta.y) ? delta.x : delta.y));

            float xIncrement = delta.x / steps;
            float yIncrement = delta.y / steps;

            float x = startPosition.x;
            float y = startPosition.y;

            for (int i = 0; i <= steps; i++) {
                var testPosition = new Vector2Int((int)x, (int)y);
                if (testPosition != startPosition) {
                    if (TryToHitSomething(testPosition, out hitColor)) {
                        return true;
                    }
                }

                x += xIncrement;
                y += yIncrement;
            }
            return false;
        }

        public bool TryToHitSomething(in Vector2Int pixelPosition, out Color hitColor) {
            hitColor = m_collisionTexture.GetPixel(pixelPosition.x, pixelPosition.y);
            return hitColor.a > 0.5f;
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
