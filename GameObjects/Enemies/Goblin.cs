using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects.Enemies
{
    internal class Goblin : Enemy
    {
        public Goblin(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            tex = AssetManager.Goblin;
            maxHealth = 10;
            CurrentHealth = maxHealth;
            curve_speed = 0.05f;
            KillReward = 25;
        }
    }
}
