﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefence.Base
{
    internal abstract class GameObject
    {
        protected Rectangle hitbox;
        protected Texture2D tex;
        public Rectangle Hitbox
        {
            get { return hitbox; }
        }
        public Texture2D Tex
        {
            get { return tex; }
        }
        public GameObject(Rectangle rect)
        {
            hitbox = rect;
        }
    }
}
