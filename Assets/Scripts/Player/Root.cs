using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class Root {
        public event Action onUpdatePoints;

        [Header("Config")]
        [SerializeField]
        float movementSpeed = 1;
        [SerializeField]
        float rotationSmoothing = 1;
        [SerializeField]
        float maxRotationSpeed = 100;

        int integerAngle => Mathf.RoundToInt(angle);
        int previousAngle = 0;

        [Header("Runtime")]
        [SerializeField]
        float angle = 180;
        [SerializeField]
        float intendedAngle = 180;
        [SerializeField]
        float rotationSpeed = 0;
        [Space]
        [SerializeField]
        List<Vector3> m_points = new();

        public Vector2 intendedDirection {
            set {
                intendedAngle = Vector2.SignedAngle(Vector2.up, value);
            }
        }

        public IReadOnlyCollection<Vector3> points => m_points;
        public Vector3 lastPosition {
            get => m_points[^1];
            set => m_points[^1] = value;
        }

        public Quaternion rotation => Quaternion.Euler(0, 0, integerAngle);
        public Vector3 forward {
            get {
                float radians = integerAngle * Mathf.Deg2Rad;
                float sin = Mathf.Sin(radians);
                float cos = Mathf.Cos(radians);

                return new Vector3(-sin, cos, 0);
            }
        }
        public Vector3 velocity => forward * movementSpeed;

        public void Reset(Vector3 position) {
            m_points.Clear();
            m_points.Add(position);
            previousAngle = integerAngle - 1;
        }

        public void Update(float deltaTime) {
            angle = Mathf.SmoothDampAngle(angle, intendedAngle, ref rotationSpeed, rotationSmoothing, maxRotationSpeed, deltaTime);

            var motion = velocity * deltaTime;
            if (previousAngle == integerAngle) {
                lastPosition += motion;
            } else {
                m_points.Add(lastPosition + motion);
                previousAngle = integerAngle;
            }
            onUpdatePoints?.Invoke();
        }
    }
}
