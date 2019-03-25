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
    public class Map
    {
        public int tileSize = 100;
        public Color backgroundColor;
        public Texture2D backgroundTexture;

        int width;
        int height;

        public Map(int w, int h)
        {
            width = w;
            height = h;
        }
        

        public GameObject[] GenerateMap()
        {
            GameObject[] tiles;
            int nbTilesX = width / tileSize;
            int nbTilesY = height / tileSize;
            tiles = new GameObject[nbTilesX * nbTilesY];
            for (int x = 0; x < nbTilesX; x++)
            {
                for (int y = 0; y < nbTilesY; y++)
                {
                    Tile tile = new Tile(x * tileSize+tileSize/2, y * tileSize + tileSize / 2, tileSize);
                    tiles[x + (y * nbTilesX)] = new GameObject("Tile");
                    tiles[x + (y*nbTilesX)].addComponent(tile);
                }
            }

            return tiles;
        }
        
    }

}