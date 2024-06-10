using Microsoft.Xna.Framework;
using TowerDefence.Base;


namespace TowerDefence.GameObjects
{
    internal class Projectile : GameObject
    {
        Vector2 position;
        Vector2 startPosition;
        float speed;

        public Projectile(Vector2 startPosition)
        {
            
            this.startPosition = startPosition;
            position = startPosition;
        }
        
    }
}
