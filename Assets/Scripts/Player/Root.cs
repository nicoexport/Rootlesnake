using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class Root {

        [SerializeField]
        public int angle = 0;
        int previousAngle = 0;

        [SerializeField]
        public float speed = 1;
        [SerializeField]
        List<Vector3> m_points = new();
        public IReadOnlyCollection<Vector3> points => m_points;
        public Vector3 lastPosition {
            get => m_points[^1];
            set => m_points[^1] = value;
        }

        public Quaternion rotation => Quaternion.Euler(0, 0, angle);
        public Vector3 forward {
            get {
                float radians = angle * Mathf.Deg2Rad;
                float sin = Mathf.Sin(radians);
                float cos = Mathf.Cos(radians);

                return new Vector3(-sin, cos, 0);
            }
        }
        public Vector3 velocity => forward * speed;

        public void Reset(Vector3 position) {
            m_points.Clear();
            m_points.Add(position);
        }

        public void Update(float deltaTime) {
            var motion = velocity * deltaTime;
            if (previousAngle == angle) {
                lastPosition += motion;
            } else {
                m_points.Add(lastPosition + motion);
                previousAngle = angle;
            }
        }
    }
}
