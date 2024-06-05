using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects
{
    internal class ArcherTower : Tower
    {
        public ArcherTower(Rectangle rect) : base(rect)
        {
            tex = AssetManager.ArcherTower;
        }
    }
}
