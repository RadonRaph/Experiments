using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TilledEnginev1._0;

namespace TilledEnginev1._0
{
    public class Actions
    {
        public virtual bool Invoke()
        {
            return false;
        }
        
    }

    public class SetActive : Actions
    {
        string ObjName;
        bool activeness;
        public SetActive(string _ObjName, bool _activeness)
        {
            ObjName = _ObjName;
            activeness = _activeness;
        }


        public override bool Invoke()
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
