using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;

namespace TilledEnginev1._0
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Utils
    {
       


        public static bool isIn(Vector2 pos, Vector2 center, float size)
        {
            if (pos.X < center.X + size / 2 && pos.X > center.X - size / 2)
            {
                if (pos.Y < center.Y + size / 2 && pos.Y > center.Y - size / 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool isInRect(Vector2 pos, int x1, int y1, int x2, int y2)
        {
            int minX = System.Math.Min(x1, x2);
            int maxX = System.Math.Max(x1, x2);
            int minY = System.Math.Min(y1, y2);
            int maxY = System.Math.Max(y1, y2);

            if (pos.X < maxX && pos.X > minX)
            {
                if (pos.Y < maxY && pos.Y > minY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

}