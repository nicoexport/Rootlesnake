using System.Collections.Generic;

namespace Rootlesnake {
    interface IPlantBranch {
        bool isAlive { get; }

        IPlant root { get; }

        IPlantNode head { get; }

        int nodeCount { get; }

        IEnumerable<IPlantNode> nodes { get; }
    }
}
