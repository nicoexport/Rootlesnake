using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Rootlesnake.Components {
    public class RawImageColorMaterialColorInfusingGuy : MonoBehaviour {
        [SerializeField] private RawImage image;
        [SerializeField] private ColorSettings outputSettings;
        [SerializeField] private ColorSettings inputSettings;
        [SerializeField] private string inputString = "_Input_";
        [SerializeField] private string outputString = "_Output_";
        

        protected void Start() {
            UpdateColors();
        }

        protected void Update() {
#if UNITY_EDITOR
        UpdateColors();
#endif
        }
        
        void UpdateColors() {
            var inp = inputSettings.colors.ToList();
            var outp = outputSettings.colors.ToList();
            
            for (int i = 0; i < inp.Count; i++) {
                var inStr = inputString + (i + 1);
                var outStr = outputString + (i + 1);

                image.material.SetColor(inStr, inp[i]);
                image.material.SetColor(outStr, outp[i]);
            }
            
        }
        
    }
    
}