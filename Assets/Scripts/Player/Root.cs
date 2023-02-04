using System;
using System.Collections.Generic;
using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class Root : IPlant {
        public event Action<IPlantBranch> onAddBranch;

        public bool isAlive { get; private set; }

        [SerializeField]
        List<RootBranch> branches = new();

        public void Reset(Vector3 position) {
            branches.Clear();
            CreateBranch(position);
            isAlive = true;
        }

        RootBranch CreateBranch(Vector3 position) {
            var branch = new RootBranch(position);
            branches.Add(branch);
            onAddBranch?.Invoke(branch);
            return branch;
        }

        public void Update(float deltaTime) {
            bool isAnyAlive = false;
            foreach (var branch in branches) {
                if (branch.isAlive) {
                    branch.Update(deltaTime);
                    if (branch.isAlive) {
                        isAnyAlive = true;
                    }
                }
            }
            isAlive = isAnyAlive;
            if (!isAlive) {
                Debug.Log("We are DED");
            }
        }

        public void SetIntendedDirection(Vector2 direction) {
            foreach (var branch in branches) {
                if (branch.isAlive) {
                    branch.intendedDirection = direction;
                }
            }
        }

        public void IntendToSplit() {
            if (!isAlive) {
                return;
            }
            var branch = branches
                .Where(branch => branch.isAlive)
                .RandomElement();
            var newBranch = branch.CreateSplit();
            branches.Add(newBranch);
            onAddBranch?.Invoke(newBranch);
        }
    }
}
