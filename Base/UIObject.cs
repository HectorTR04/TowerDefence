using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace TowerDefence.Base
{
    internal class UIObject
    {
        protected Rectangle hitbox;
        protected Texture2D tex;
        public Rectangle Hitbox
        {
            get { return hitbox; }
        }
        public UIObject(Rectangle hitbox)
        {
            this.hitbox = hitbox;
        }
    }
}
