
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;

namespace TowerDefence.GameObjects
{
    internal abstract class Tower : GameObject
    {
        int price;
        int damage;

        public Tower()
        {
        }

        public void SetRectangle(Rectangle rect)
        {
            Hitbox = rect;  
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, Hitbox, Color.White);
        }
    }
}
