using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.GameObjects
{
    internal class IceBall : Projectile
    {
        public IceBall(Vector2 startPosition, Vector2 targetPosition) : base(startPosition, targetPosition)
        {
        }
    }
}
