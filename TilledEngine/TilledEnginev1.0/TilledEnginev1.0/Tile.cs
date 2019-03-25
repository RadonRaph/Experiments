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
    public class Tile
    {
        public int posX;
        public int posY;
        public int size;
        public static MainGame game;
        public static SpriteBatch batch;

        bool isClicked;
        bool isMenu;
        Menu tileMenu;

        public Tile(int x, int y, int size)
        {
            posX = x;
            posY = y;
            this.size = size;


            game = Program.game;
            batch = game.spriteBatch;

            tileMenu = new Menu(x, y);
            tileMenu.AddSub(Color.IndianRed, "Construire", constructMenu);
            //tileMenu.AddSub(Color.IndianRed, "");
        }


        bool constructMenu()
        {
            Menu cstrctMenu = new Menu(posX, posY);
            cstrctMenu.AddSub(Color.Yellow, "Maison");
            game.menuToDraw = cstrctMenu;

            return true;
        }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();
            ButtonState leftClic = mouse.LeftButton;
            ButtonState rightClic = mouse.RightButton;

            if (leftClic == ButtonState.Pressed)
            {
                Vector2 mousePos = new Vector2(mouse.X, mouse.Y);
                if (Utils.isIn(mousePos, new Vector2(posX, posY), size))
                {
                    isClicked = true;
                    if (game.menuToDraw == tileMenu)
                        game.menuToDraw = null;
                }
                else
                {
                    isClicked = false;
                    if (game.menuToDraw == tileMenu)
                        game.menuToDraw = null;
                }
            }

            if (rightClic == ButtonState.Pressed)
            {
                Vector2 mousePos = new Vector2(mouse.X, mouse.Y);
                if (Utils.isIn(mousePos, new Vector2(posX, posY), size))
                {
                    isClicked = true;
                    game.menuToDraw = tileMenu;
                }
                else
                {
                    isClicked = false;
                }
            }
            
        }

        public void Draw()
        {
            MouseState mouse = Mouse.GetState();
            Vector2 mousePos = new Vector2(mouse.X, mouse.Y);
            
            
            

            if (Utils.isIn(mousePos, new Vector2(posX, posY), size) || isClicked)
            {
                drawHovered();
            }
            else
            {
                drawDefault();
            }


        }

        void drawDefault()
        {
            batch.Draw(BasicShapes.Rect(size, size), new Vector2(posX - size / 2, posY - size / 2), Color.White);
            batch.Draw(BasicShapes.Rect(size, size, false, size/10), new Vector2(posX - size / 2, posY - size / 2), Color.LightGray);
        }

        void drawHovered()
        {
            batch.Draw(BasicShapes.Rect(size, size), new Vector2(posX - size / 2, posY - size / 2), Color.Gray);
            batch.Draw(BasicShapes.Rect(size, size, false, size / 15), new Vector2(posX - size / 2, posY - size / 2), Color.DarkGray);
        }

    }

}