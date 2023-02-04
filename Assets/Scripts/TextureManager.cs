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
                name = "Playfield"
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

            GL.Color(Color.white);
            GL.Begin(GL.LINES);
        }

        public void DrawLineWorldSpace(Vector3 start, Vector3 stop) {
            start += playSpace.position.SwizzleXY();
            stop += playSpace.position.SwizzleXY();

            start.x /= playSpace.width;
            start.y /= playSpace.height;

            stop.x /= playSpace.width;
            stop.y /= playSpace.height;

            GL.Vertex(start);
            GL.Vertex(stop);
        }

        void PostMoveRoots() {
            GL.End();

            GL.PopMatrix();

            RenderTexture.active = previousTexture;
        }
    }
}
