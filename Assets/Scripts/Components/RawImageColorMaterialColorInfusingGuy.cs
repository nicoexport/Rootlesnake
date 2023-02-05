using System.Linq;
using UnityEngine;

namespace Rootlesnake.Components {
    public class RawImageColorMaterialColorInfusingGuy : MonoBehaviour {
        [SerializeField] Material material;
        [SerializeField] string inputString = "_Input_";
        [SerializeField] string outputString = "_Output_";


        protected void Start() {
            UpdateColors();
            material.SetTexture("_MainTex", TextureManager.instance.collisionTexture);
        }

#if UNITY_EDITOR
        protected void Update() {
            UpdateColors();
        }
#endif

        void UpdateColors() {
            var inp = GameManager.instance.collisionColors.colors.ToList();
            var outp = GameManager.instance.playfieldColors.colors.ToList();

            for (int i = 0; i < inp.Count; i++) {
                string inStr = inputString + (i + 1);
                string outStr = outputString + (i + 1);

                material.SetColor(inStr, inp[i]);
                material.SetColor(outStr, outp[i]);
            }
        }

    }

}