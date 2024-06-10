using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects
{
    internal class IceBall : Projectile
    {
        public IceBall(Vector2 startPosition, Vector2 targetPosition) : base(startPosition, targetPosition)
        {
            tex = AssetManager.IceBall;
            speed = 50f;
            hitbox = new Rectangle((int)position.X, (int)position.Y, AssetManager.IceBall.Width, AssetManager.IceBall.Height);
        }
    }
}
