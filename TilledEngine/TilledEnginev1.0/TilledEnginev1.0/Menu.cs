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

        public void AddSub(Color  bg, string title, Actions[] actions)
        {
            subMenus.Add(new SubMenu(bg, title, actions));
        }
        
    }


    public class SubMenu
    {
        public Color backgroundColor;
        public String Text;
        Actions[] actions;

        public SubMenu(Color bg, string text, Actions[] fonctions)
        {
            backgroundColor = bg;
            Text = text;
            actions = fonctions;
        }

        public void onClick()
        {
           Program.game.menuToDraw = null;

            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Invoke();
            }
            //EEEEEEEEVEEEEEEEEEEnt

            
        }
    }



    public static class HUD
    {
        public static void Start()
        {
            Menu tileMenu = new Menu(0, 0);
            SetActive[] actions = new SetActive[2];
            actions[0] = new SetActive("BuildMenu", true);
            actions[1] = new SetActive("TileMenu", false);
            SubMenu build = new SubMenu(Color.HotPink, "Constuire", actions);
            GameObject tileMenuObj = new GameObject("TileMenu", 1);
            tileMenuObj.addComponent(tileMenu);

            tileMenuObj.active = false;
            Program.game.gameObjects.Add(tileMenuObj);
            //GAMEOBJECT
        }

        
        
    }

}