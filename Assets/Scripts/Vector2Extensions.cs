using UnityEngine;

namespace Rootlesnake {
    static class Vector2Extensions {
        public static Vector2 Rotate(this in Vector2 direction, float degrees) {
            float radians = degrees * Mathf.Deg2Rad;
            float sin = Mathf.Sin(radians);
            float cos = Mathf.Cos(radians);

            float x = direction.x;
            float y = direction.y;

            return new(
                (cos * x) - (sin * y),
                (sin * x) + (cos * y)
            );
        }
    }
}
