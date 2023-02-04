using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rootlesnake {
    interface IPlantBranch {
        event Action<Vector3, Vector3> onUpdateHeadPosition;
        event Action onUpdateNodePositions;
        event Action onUpdateNodeCount;

        bool isAlive { get; }

        IPlant root { get; }

        IPlantNode head { get; }

        int nodeCount { get; }

        IEnumerable<IPlantNode> nodes { get; }
    }
}
