using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TowerDefence.GameObjects;

namespace TowerDefence.Managers
{
    internal class EnemyManager
    {
        List<Enemy> enemies;
        GraphicsDevice graphicsDevice;
        int timeSinceLastSpawn = 0;
        int millisecondsBetweenCreation = 3000;
        int enemiesInCurrentWave = 5;

        public EnemyManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            enemies = new List<Enemy>();
        }
        void LoadWave(GameTime gameTime)
        {
            timeSinceLastSpawn += gameTime.ElapsedGameTime.Milliseconds;
            if (enemiesInCurrentWave > 0 && timeSinceLastSpawn > millisecondsBetweenCreation)
            {
                timeSinceLastSpawn -= millisecondsBetweenCreation;
                Goblin goblin = new Goblin(graphicsDevice);
                enemies.Add(goblin);
                --enemiesInCurrentWave;
            }
        }
        public void Update(GameTime gameTime)
        {
            LoadWave(gameTime);
            foreach(Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
