using System;
using System.Collections.Generic;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace Rootlesnake.Collision {
    sealed class CollisionManager : MonoBehaviour 
    {
        Texture2D collisionMap;



        public bool checkIfMoveIsPossible(Vector2 startPosition, Vector2 intendedMove) {
            //get all Pixels inbetween the currentPosition and the position after moving
            Vector2 targetPosition = startPosition + intendedMove;

            bool isPossible = true;
            int x0 = (int)startPosition.x;
            int y0 = (int)startPosition.y;

            int x1 = (int)targetPosition.x;
            int y1 = (int)targetPosition.y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true) {
                if(collisionMap.GetPixel(x0,y0).a > 0.5f) 
                {
                    isPossible = false;
                }

                if (x0 == x1 && y0 == y1)
                    break;
                int e2 = 2 * err;
                if (e2 > -dy) {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx) {
                    err += dx;
                    y0 += sy;
                }
            }

            return isPossible;
        }


        // function for line generation
        //public static List<Tuple<int, int>> GetLine(int x0, int y0, int x1, int y1) {
        //    List<Tuple<int, int>> points = new List<Tuple<int, int>>();
        //    int dx = Math.Abs(x1 - x0);
        //    int dy = Math.Abs(y1 - y0);
        //    int sx = x0 < x1 ? 1 : -1;
        //    int sy = y0 < y1 ? 1 : -1;
        //    int err = dx - dy;

        //    while (true) {
        //        points.Add(new Tuple<int,int>(x0, y0));

        //        if (x0 == x1 && y0 == y1)
        //            break;
        //        int e2 = 2 * err;
        //        if (e2 > -dy) {
        //            err -= dy;
        //            x0 += sx;
        //        }
        //        if (e2 < dx) {
        //            err += dx;
        //            y0 += sy;
        //        }
        //    }

        //    return points;
        //}

    }
}
