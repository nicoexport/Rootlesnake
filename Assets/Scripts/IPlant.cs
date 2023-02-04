using System;
using UnityEngine;

namespace Rootlesnake {
    interface IPlant {
        event Action<IPlantBranch> onAddBranch;

        bool isAlive { get; }

        int playerIndex { get; }

        Color playerColor { get; }

        void SetIntendedDirection(Vector2 direction);

        void IntendToSplit();
    }
}
