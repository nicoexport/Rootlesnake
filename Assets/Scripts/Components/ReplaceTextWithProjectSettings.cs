using System.Collections.Generic;
using TMPro;
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
                yield return (nameof(Application.companyName), Application.companyName);
                yield return (nameof(Application.version), Application.version);
                yield return (nameof(Application.productName), Application.productName);
            }
        }

        void Start() {
            foreach (var (search, replace) in replacements) {
                textMesh.text = textMesh.text.Replace('{' + search + '}', replace);
            }
        }
    }
}
