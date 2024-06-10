using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects
{
    internal class Orc : Enemy
    {
        public Orc(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            tex = AssetManager.Orc;
            health = 20;
            curve_speed = 0.05f;
        }
    }
}
