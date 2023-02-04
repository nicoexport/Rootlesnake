using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Rendering;

namespace Rootlesnake.Player {
    sealed class RootTextureRenderer : MonoBehaviour {
        [SerializeField, Expandable]
        RenderTexture targetTexture;

        public RenderTexture renderTexture;
        private List<Vector3> linePoints;
        public Material lineMaterial;

        void Start() {
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTexture;

            GL.PushMatrix();
            lineMaterial.SetPass(0);
            GL.LoadOrtho();
            GL.Begin(GL.LINES);
            GL.Color(Color.red);
            for (int i = 0; i < linePoints.Count - 1; i++) {
                GL.Vertex(linePoints[i]);
                GL.Vertex(linePoints[i + 1]);
            }
            GL.End();
            GL.PopMatrix();
        }
    }
}
