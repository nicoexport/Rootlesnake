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

            normalizedPosition.x += playSpaceSize.x * 0.5f;
            normalizedPosition.y += playSpaceSize.y * 0.5f;
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

        public bool TryToHitSomething(in Vector3 worldStartPosition, in Vector3 worldMotion, in Color ownColor, out Color hitColor) {
            //get all Pixels inbetween the currentPosition and the position after movin
            hitColor = Color.black;

            var worldTargetPosition = worldStartPosition + worldMotion;

            var startPosition = WorldSpaceToTexture2DSpace(worldStartPosition);
            var targetPosition = WorldSpaceToTexture2DSpace(worldTargetPosition);

            if (IsOutOfBounds(targetPosition)) {
                return true;
            }

            if (startPosition == targetPosition) {
                return false;
            }

            var delta = startPosition - targetPosition;

            int steps = Mathf.Abs(Mathf.Abs(delta.x) > Mathf.Abs(delta.y) ? delta.x : delta.y);

            float xIncrement = delta.x / (float)steps;
            float yIncrement = delta.y / (float)steps;

            float x = startPosition.x;
            float y = startPosition.y;

            for (int i = 0; i <= steps; i++) {
                if (TryToHitSomething(new((int)x, (int)y), ownColor, out hitColor)) {
                    return true;
                }

                x += xIncrement;
                y += yIncrement;
            }
            return false;
        }
        public bool TryToHitSomething(in Vector2Int texture2DPosition, in Color ownColor, out Color hitColor) {
            hitColor = m_collisionTexture.GetPixel(texture2DPosition.x, texture2DPosition.y);
            if (hitColor == ownColor) {
                return false;
            }
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
