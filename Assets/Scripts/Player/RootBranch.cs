using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class RootBranch : IPlantBranch {
        public event Action onUpdateBranch;

        public bool isAlive { get; private set; }

        public IPlantNode head => m_head;

        [SerializeReference]
        RootNode m_head;

        public int nodeCount { get; private set; }

        public IEnumerable<IPlantNode> nodes {
            get {
                for (var node = head; node is not null; node = node.parent) {
                    yield return node;
                }
            }
        }

        [Header("Config")]
        [SerializeField]
        float movementSpeed = 1;
        [SerializeField]
        float rotationSmoothing = 1;
        [SerializeField]
        float maxRotationSpeed = 100;
        [SerializeField]
        float splitAngle = 15;

        int integerAngle => Mathf.RoundToInt(angle);
        int previousAngle = 0;

        [Header("Runtime")]
        [SerializeField]
        float angle = 180;
        [SerializeField]
        float intendedAngle = 180;
        [SerializeField]
        float rotationSpeed = 0;

        public RootBranch(Vector3 position) {
            m_head = new(position);
            isAlive = true;
            nodeCount = 1;

            previousAngle = integerAngle - 1;
        }
        public RootBranch(RootBranch parent, float angle) {
            m_head = parent.m_head;
            isAlive = parent.isAlive;
            nodeCount = parent.nodeCount;

            this.angle = intendedAngle = angle;
            previousAngle = integerAngle - 1;
        }

        public Vector2 intendedDirection {
            set {
                intendedAngle = Vector2.SignedAngle(Vector2.up, value);
            }
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

        public void Update(float deltaTime) {
            angle = Mathf.SmoothDampAngle(angle, intendedAngle, ref rotationSpeed, rotationSmoothing, maxRotationSpeed, deltaTime);

            var motion = velocity * deltaTime;
            if (previousAngle == integerAngle) {
                m_head.position += motion;
            } else {
                nodeCount++;
                m_head = m_head.CreateChild(motion);
                previousAngle = integerAngle;
            }
            onUpdateBranch?.Invoke();
        }

        public RootBranch CreateSplit() {
            float leftAngle = angle - splitAngle;
            float rightAngle = angle + splitAngle;
            angle = intendedAngle = leftAngle;
            previousAngle = integerAngle - 1;

            return new(this, rightAngle);
        }
    }
}
