using UnityEngine;

namespace Rootlesnake {
    interface IPlantNode {
        IPlantNode parent { get; }
        Vector3 position { get; }
    }
}
