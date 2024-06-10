using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects.Enemies
{
    internal class Orc : Enemy
    {
        public Orc(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            tex = AssetManager.Orc;
            maxHealth = 20;
            CurrentHealth = maxHealth;
            curve_speed = 0.05f;
            KillReward = 50;
        }
    }
}
