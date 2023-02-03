using MyBox;
using UnityEngine;

namespace Rootlesnake.Effects {
    abstract class ScriptableEffect : ScriptableObject {
        [SerializeField, ReadOnly]
        ScriptableEffect effect;

        protected virtual void OnValidate() {
            if (!effect) {
                effect = this;
            }
        }

        public void Invoke() {
            InvokeNow(default);
        }
        public void Invoke(GameObject context) {
            InvokeNow(context);
        }

        protected abstract void InvokeNow(GameObject context);
    }
}
