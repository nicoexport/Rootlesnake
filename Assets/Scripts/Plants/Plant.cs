using System;
using UnityEngine;

namespace Rootlesnake.Plants {
    public class Plant : MonoBehaviour {
        [SerializeField] private GameObject[] plantStages;
        [SerializeField, Range(0f, 100f)] private float plantProgress;
        [SerializeField] private float maxProgress = 100;
        
        protected void Update() {
            UpdatePlant();
        }
        
        public void UpdatePlant() {
            float step = maxProgress / plantStages.Length;
            var sum = 0f;
            for (int i = 0; i < plantStages.Length; sum += step, i ++) {
                if(plantProgress >= sum)
                {
                    plantStages[i].SetActive(true);
                } else {
                    plantStages[i].SetActive(false);
                }
            }
        }
    }
}