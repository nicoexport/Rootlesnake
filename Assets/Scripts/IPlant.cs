using System;
using UnityEngine;

namespace Rootlesnake {
    interface IPlant {
        event Action<IPlantBranch> onAddBranch;

        void SetIntendedDirection(Vector2 direction);

        void IntendToSplit();
    }
}
