using System;
using UnityEngine;

namespace Rootlesnake {
    interface IPlant {
        event Action<IPlantBranch> onAddBranch;

        bool isAlive { get; }

        void SetIntendedDirection(Vector2 direction);

        void IntendToSplit();
    }
}
