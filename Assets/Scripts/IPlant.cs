using System;
using UnityEngine;

namespace Rootlesnake {
    interface IPlant {
        event Action<IPlantBranch> onAddBranch;

        bool isAlive { get; }

        int playerIndex { get; }

        Color aliveColor { get; }

        Color deadColor { get; }

        void SetIntendedDirection(Vector2 direction);

        void IntendToSplit();
    }
}
