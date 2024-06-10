using Microsoft.Xna.Framework;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects
{
    internal class Arrow : Projectile
    {
        public Arrow(Vector2 startPosition, Vector2 targetPosition) : base(startPosition, targetPosition)
        {
            tex = AssetManager.Arrow;
            speed = 10f;
        }

    }
}
