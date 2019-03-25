using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;

namespace TilledEnginev1._0
{
    /// <summary>
    /// The main class.
    /// </summary>
    public class Menu : Component{

        public int posX;
        public int posY;
        public List<SubMenu> subMenus;

        public static MainGame game;
        public static SpriteBatch batch;


        public Menu(int x, int y)
        {
            posX = x;
            posY = y;
            game = Program.game;
            batch = game.spriteBatch;

            subMenus = new List<SubMenu>();
        }


        public override void Draw()
        {
            MouseState mouse = Mouse.GetState();
            for (int i = 0; i < subMenus.Count; i++)
            {
                batch.Draw(BasicShapes.Rect(300, 75), new Vector2(posX, posY+75*i), subMenus[i].backgroundColor);
                batch.DrawString(game.font, subMenus[i].Text, new Vector2(posX, posY + 75 * i), Color.Black);

                if (Utils.isInRect(mouse.Position.ToVector2(), posX, posY+75*i, posX+300, posY + 75 * (i + 1)))
                {
                    batch.Draw(BasicShapes.Rect(300, 75, false, 5), new Vector2(posX, posY + 75 * i), Color.Black);
                    Mouse.SetCursor(MouseCursor.Hand);
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        subMenus[i].onClick();
                    }
                }
                else
                {
                    Mouse.SetCursor(MouseCursor.Arrow);
                }
            }
        }

        public void AddSub(Color  bg, string title, Func<bool> func = null)
        {
            subMenus.Add(new SubMenu(bg, title, func));
        }
        
    }


    public class SubMenu
    {
        public Color backgroundColor;
        public String Text;
        Func<bool> action;

        public SubMenu(Color bg, string text, Func<bool> func = null)
        {
            backgroundColor = bg;
            Text = text;
            action = func;
        }

        public void onClick()
        {
           Program.game.menuToDraw = null;

            if (action != null)
            action();

            
        }
    }

}