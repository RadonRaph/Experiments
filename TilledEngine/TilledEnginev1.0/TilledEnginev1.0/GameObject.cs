using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;

namespace TilledEnginev1._0
{
    public class GameObject
    {
        public List<Component> components;

        public string name;
        public int orderInLayer;

        public Vector2 position;

        public GameObject(string name, int orderInLayer = 0)
        {
            components = new List<Component>();
            this.name = name;
        }
        // Use this for initialization
        public void Start()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Start();
            }
        }

        // Update is called once per frame
        public void Update()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Update();

                //TODOO ONCLIK AND COLLIDER
                //if (Mouse.GetState().)
            }
        }


        public void Draw()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Draw();
            }
        }

        public void addComponent(Component component)
        {
            components.Add(component);
        }


        public  Component GetComponent(Component component)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] == component)
                    return (components[i]);
                else
                {
                    return null;
                }
            }
            return null;
        }

        public static GameObject Find(string name)
        {
            for (int i = 0; i < Program.game.gameObjects.Count; i++)
            {
                if (Program.game.gameObjects[i].name == name)
                {
                    return Program.game.gameObjects[i];
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
