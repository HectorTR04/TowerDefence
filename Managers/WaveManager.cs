using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TowerDefence.Base;

namespace TowerDefence.Managers
{
    internal class WaveManager
    {
        List<Wave> waves;
        public WaveManager()
        {
            waves = new List<Wave>();
        }

        public void CreateWave(GraphicsDevice gd)
        {
            waves.Add(new Wave(gd));
        }

        public void Update(GameTime gameTime, int wave)
        {
            waves[wave - 1].Update(gameTime);
        }

        public void Draw(SpriteBatch sb, int wave)
        {
            waves[wave - 1].Draw(sb);
        }
    }
}
