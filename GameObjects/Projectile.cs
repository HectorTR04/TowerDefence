using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;


namespace TowerDefence.GameObjects
{
    internal class Projectile : GameObject
    {
        Vector2 position;
        Vector2 startPosition;
        Vector2 targetPosition;
        protected float speed;

        public Projectile(Vector2 startPosition, Vector2 targetPosition)
        {         
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            position = startPosition;
        }
        public void Update(GameTime gameTime)
        {
            Vector2 direction = Vector2.Normalize(targetPosition - position);
            float distanceToMove = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += direction * distanceToMove;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, position, Color.White);
        }
        
    }
}
