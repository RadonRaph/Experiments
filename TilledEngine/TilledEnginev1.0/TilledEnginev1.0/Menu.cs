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
            posX = mouse.Position.X;
            posY = mouse.Position.Y;
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

        public void AddSub(Color  bg, string title, Action<string, bool> func = null)
        {
            subMenus.Add(new SubMenu(bg, title, func));
        }
        
    }


    public class SubMenu
    {
        public Color backgroundColor;
        public String Text;
        Action<string, bool> action;

        public SubMenu(Color bg, string text, Action<string, bool> func = null)
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
            //EEEEEEEEVEEEEEEEEEEnt

            
        }
    }



    public static class HUD
    {
        public static void Start()
        {
            Menu tileMenu = new Menu(0, 0);
            Action<string, bool> action = new Action<string, bool>(setActive);
            SubMenu build = new SubMenu(Color.HotPink, "Constuire", action);
        }

        
        public static void setActive(string ObjName, bool activeness)
        {
            if (GameObject.Find(ObjName) != null)
            {
                GameObject.Find(ObjName).active = activeness;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}