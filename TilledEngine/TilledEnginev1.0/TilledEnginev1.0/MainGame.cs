﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TilledEnginev1._0
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

       // Tile[] tiles;
        Map map;
        public List<GameObject> gameObjects;

        public Menu menuToDraw;

        public int width = 1600;
        public int height = 900;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = width;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = height;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            base.IsMouseVisible = true;

            

            Content.RootDirectory = "Content";

            gameObjects = new List<GameObject>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

           
           
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            font = Content.Load<SpriteFont>("Font");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = new Map(width, height);
            int tilesLength = map.GenerateMap().Length;
            for (int i = 0; i < tilesLength; i++)
            {
                gameObjects.Add(map.GenerateMap()[i]);
            }


            HUD.Start();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].active) 
                gameObjects[i].Start();
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].Update();
            }*/
            //Console.Clear();
          //  Debug.Write("===================================================================");
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].active)
                {
                    gameObjects[i].Update();
                  //  Debug.WriteLine("O" + gameObjects[i].name);
                }
                else
                {
                 //   Debug.WriteLine("F" + gameObjects[i].name);
                }
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here



            int maxLayer = 0;
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw();
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
