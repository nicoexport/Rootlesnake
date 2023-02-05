using System;
using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class Root : IPlant {
        public event Action<IPlantBranch> onAddBranch;

        public bool isAlive => branches.Count > 0;

        int m_playerIndex;
        public int playerIndex {
            get => m_playerIndex;
            set {
                m_playerIndex = value;
                aliveColor = value switch {
                    0 => GameManager.instance.collisionColors.playerOne,
                    1 => GameManager.instance.collisionColors.playerTwo,
                    2 => GameManager.instance.collisionColors.playerThree,
                    3 => GameManager.instance.collisionColors.playerFour,
                    _ => throw new NotImplementedException(),
                };
                deadColor = value switch {
                    0 => GameManager.instance.collisionColors.deadPlayerOne,
                    1 => GameManager.instance.collisionColors.deadPlayerTwo,
                    2 => GameManager.instance.collisionColors.deadPlayerThree,
                    3 => GameManager.instance.collisionColors.deadPlayerFour,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public Color aliveColor { get; private set; }

        public Color deadColor { get; private set; }

        [SerializeField]
        bool onlyOneChildSplit = false;
        [SerializeField]
        List<RootBranch> branches = new();

        readonly List<RootBranch> tmpBranches = new();

        public void Reset(Vector3 position) {
            branches.Clear();
            CreateBranch(position);
        }

        RootBranch CreateBranch(Vector3 position) {
            var branch = new RootBranch(this, position);
            branches.Add(branch);
            onAddBranch?.Invoke(branch);
            return branch;
        }

        public void Update(float deltaTime) {
            tmpBranches.Clear();
            foreach (var branch in branches) {
                branch.Update(deltaTime);
                if (!branch.isAlive) {
                    tmpBranches.Add(branch);
                }
            }
            foreach (var branch in tmpBranches) {
                branches.Remove(branch);
            }
            if (!isAlive) {
                Debug.Log("We are DED");
            }
        }

        public void SetIntendedDirection(Vector2 direction) {
            foreach (var branch in branches) {
                branch.intendedDirection = direction;
            }
        }

        public void IntendToSplit() {
            if (!isAlive) {
                return;
            }
            if (onlyOneChildSplit) {
                var branch = branches.RandomElement();
                var newBranch = branch.CreateSplit();
                branches.Add(newBranch);
                onAddBranch?.Invoke(newBranch);
            } else {
                tmpBranches.Clear();
                foreach (var branch in branches) {
                    tmpBranches.Add(branch.CreateSplit());
                }
                foreach (var branch in tmpBranches) {
                    branches.Add(branch);
                    onAddBranch?.Invoke(branch);
                }
            }
        }
    }
}
