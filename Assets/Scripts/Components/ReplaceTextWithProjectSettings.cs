using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Rootlesnake.Components {
    sealed class ReplaceTextWithProjectSettings : MonoBehaviour {
        [SerializeField]
        TextMeshProUGUI textMesh;

        void OnValidate() {
            if (!textMesh) {
                TryGetComponent(out textMesh);
            }
        }

        IEnumerable<(string, string)> replacements {
            get {
                yield return (nameof(PlayerSettings.companyName), PlayerSettings.companyName);
                yield return (nameof(PlayerSettings.bundleVersion), PlayerSettings.bundleVersion);
                yield return (nameof(PlayerSettings.productName), PlayerSettings.productName);
            }
        }

        void Start() {
            foreach (var (search, replace) in replacements) {
                textMesh.text = textMesh.text.Replace('{' + search + '}', replace);
            }
        }
    }
}
