using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TilledEnginev1._0
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BasicShapes
    {

        public static GraphicsDevice gd;

        public static Texture2D Rect(int width, int height, bool fill = true, int borderHeight = 0)
        {
            Console.Write(width);
            Texture2D rect = new Texture2D(gd, width, height);
            Color[] data = new Color[width * height];

            if (fill == true)
            {
                for (int i = 0; i < data.Length; ++i)
                    data[i] = Color.White;
            }
            else
            {
                for (int i = 0; i < data.Length; ++i)
                    data[i] = Color.Transparent;

                for (int x = 0; x < borderHeight; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        data[x+y*width] = Color.White;
                        data[(width - x - 1) + (height - y - 1) * width] = Color.White;
                    }
                }

                for (int y = 0; y < borderHeight; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        data[x+y*width] = Color.White;
                        data[(width - x-1) + (height - y-1) * width] = Color.White;
                    }
                }
            }

            rect.SetData(data);
            return rect;
        }

        public static Texture2D Circle(float radius, bool fill = true, int borderHeight = 0)
        {
            Texture2D rect = new Texture2D(gd, (int)radius, (int)radius);
            
            Color[] data = new Color[(int)radius * (int)radius];

            Vector2 center = new Vector2(radius / 2, radius / 2);
            float min = 0;
            if (fill == false)
            {
                min = radius/2 - borderHeight; 
            }

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    Vector2 pos = new Vector2(x, y);
                    // Console.WriteLine(Vector2.Distance(center, pos));
                    if (Vector2.Distance(center, pos) < radius / 2 && Vector2.Distance(center, pos) > min)
                        data[x + y * (int)radius] = Color.White;
                    else
                        data[x + y * (int)radius] = Color.Transparent;

                }
            }

            rect.SetData(data);
            return rect;
        }
    }

}