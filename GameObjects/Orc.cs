using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects
{
    internal class Orc : Enemy
    {
        public Orc(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            tex = AssetManager.Orc;
            maxHealth = 20;
            currentHealth = maxHealth;
            curve_speed = 0.05f;
        }
    }
}
