using System.Collections;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;

namespace TilledEnginev1._0
{
    public abstract class Component
    {

        public GameObject gameObject;

        // Use this for initialization
        public virtual void Start()
        {

        }

        // Update is called once per frame
        public virtual void Update()
        {

        }

        public virtual void OnClick(int clic)
        {

        }

        public virtual void Draw()
        {

        }
    }
}
