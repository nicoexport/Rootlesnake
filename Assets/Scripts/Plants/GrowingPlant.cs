using System;
using UnityEngine;
using UnityEngine.Events;

namespace Rootlesnake.Plants {
    public class GrowingPlant : MonoBehaviour {
        [SerializeField] GameObject[] plantStages;
        [SerializeField, Range(0f, 100f)] float plantProgress;
        [SerializeField] float maxProgress = 100;
        [SerializeField] private UnityEvent onFeed;

        protected void Start() {
            UpdatePlant();
        }

        public void UpdatePlant() {
            plantProgress += 1f;
            
            float step = maxProgress / plantStages.Length;
            float sum = 0f;
            for (int i = 0; i < plantStages.Length; sum += step, i++) {
                if (plantProgress >= sum) {
                    plantStages[i].SetActive(true);
                } else {
                    plantStages[i].SetActive(false);
                }
            }
            onFeed.Invoke();
        }

        public void SetColor(Color color) {
            
            
            foreach (var stage in plantStages) {
                if (stage.TryGetComponent(out Renderer rend)) {
                    var tempCol = GameManager.instance.CollisionColorToPlayfieldColor(color);   
                    rend.material.SetColor("_InputColor", tempCol);
                }
            }
        }
    }
}