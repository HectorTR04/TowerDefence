using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects
{
    internal class MageTower : Tower
    {
        public MageTower()
        {
            tex = AssetManager.MageTower;
            price = 200;
            damage = 5;
            shotCoolDown = 3000;
        }
        public override void FireProjectile(Vector2 targetPosition)
        {
            IceBall iceBall = new IceBall(position, targetPosition);
            projectiles.Add(iceBall);
        }
    }
}
