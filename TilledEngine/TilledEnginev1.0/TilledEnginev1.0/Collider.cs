using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;

namespace TilledEnginev1._0
{
    

    public class Collider
    {

        public Vector2 position;

        public virtual bool isClicked(int clic)
        {
            return false;
        }

        public virtual bool isTrigerred()
        {
            return false;
        }
    }


    public class RectCollider : Collider
    {
        float xMin;
        float xMax;
        float yMin;
        float yMax;

        public RectCollider(float x1, float y1, float x2, float y2)
        {
            xMin = System.Math.Min(x1, x2);
            xMax = System.Math.Max(x1, x2);
            yMin = System.Math.Min(y1, y2);
            yMax = System.Math.Max(y1, y2);
        }

        public override bool isClicked(int clic)
        {
            MouseState mouse = Mouse.GetState();

            if (clic == 0 && mouse.LeftButton == ButtonState.Pressed || clic == 1 && mouse.RightButton == ButtonState.Pressed)
            {
                if (Utils.isInRect(mouse.Position.ToVector2(), (int)xMin, (int)yMin, (int)xMax, (int)yMax))
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
