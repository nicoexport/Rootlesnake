using System;
using System.Collections.Generic;
using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class Root : IPlant {
        public event Action<IPlantBranch> onAddBranch;

        [SerializeField]
        List<RootBranch> branches = new();

        public void Reset(Vector3 position) {
            branches.Clear();
            CreateBranch(position);
        }

        RootBranch CreateBranch(Vector3 position) {
            var branch = new RootBranch(position);
            branches.Add(branch);
            onAddBranch?.Invoke(branch);
            return branch;
        }

        public void Update(float deltaTime) {
            foreach (var branch in branches) {
                if (branch.isAlive) {
                    branch.Update(deltaTime);
                }
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
            var branch = branches
                .Where(branch => branch.isAlive)
                .RandomElement();
            var newBranch = branch.CreateSplit();
            branches.Add(newBranch);
            onAddBranch?.Invoke(newBranch);
        }
    }
}
