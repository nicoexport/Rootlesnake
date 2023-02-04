using System;
using System.Collections.Generic;

namespace Rootlesnake {
    interface IPlantBranch {
        event Action onUpdateNodePositions;
        event Action onUpdateNodeCount;

        bool isAlive { get; }

        IPlantNode head { get; }

        int nodeCount { get; }

        IEnumerable<IPlantNode> nodes { get; }
    }
}
