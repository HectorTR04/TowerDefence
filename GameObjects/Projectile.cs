using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DXGI;
using TowerDefence.Base;


namespace TowerDefence.GameObjects
{
    internal class Projectile : GameObject
    {
        protected Vector2 position;
        Vector2 targetPosition;
        protected float speed;
        bool isActive;
        public bool IsActive { get { return isActive; } }

        public Projectile(Vector2 startPosition, Vector2 targetPosition)
        {         
            this.targetPosition = targetPosition;
            position = startPosition;
            isActive = true;
        }
        public void Update(GameTime gameTime)
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
            Vector2 direction = Vector2.Normalize(targetPosition - position);
            float distanceToMove = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += direction * distanceToMove;
            if(Vector2.Distance(position, targetPosition) <= distanceToMove)
            {
                isActive = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, position, Color.White);
        }
        
    }
}
