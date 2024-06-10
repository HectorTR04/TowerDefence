using Microsoft.Xna.Framework;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects.Towers
{
    internal class ArcherTower : Tower
    {
        public ArcherTower()
        {
            tex = AssetManager.ArcherTower;
            price = 100;
            damage = 2;
            shotCoolDown = 1000;
        }
        public override void FireProjectile(Vector2 targetPosition)
        {
            Arrow arrow = new Arrow(position, targetPosition);
            projectiles.Add(arrow);
        }
    }
}
