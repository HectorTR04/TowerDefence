using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TowerDefence.GameObjects;

namespace TowerDefence.Managers
{
    internal class EnemyManager
    {
        Random random;
        List<Enemy> enemiesInCurrentWave;
        GraphicsDevice graphicsDevice;
        int timeSinceLastSpawn = 0;
        int millisecondsBetweenCreation = 1000;
        int enemiesToSpawn = 7;
        public bool WaveActive { get; private set; } = false;
        

        public EnemyManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            random = new Random();
            enemiesInCurrentWave = new List<Enemy>();
        }
        void LoadWave(GameTime gameTime)
        {
            timeSinceLastSpawn += gameTime.ElapsedGameTime.Milliseconds;
            WaveActive = true;
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                if (timeSinceLastSpawn > millisecondsBetweenCreation)
                {
                    timeSinceLastSpawn -= millisecondsBetweenCreation;
                    int randomEnemyType = random.Next(0,2);
                    if(randomEnemyType == 0)
                    {
                        Enemy newEnemy = new Goblin(graphicsDevice);
                        enemiesInCurrentWave.Add(newEnemy);
                    }
                    else
                    {
                        Enemy newEnemy = new Orc(graphicsDevice);
                        enemiesInCurrentWave.Add(newEnemy);
                    }
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            LoadWave(gameTime);
            foreach(Enemy enemy in enemiesInCurrentWave)
            {
                if(WaveActive && enemy.IsAlive)
                {
                    enemy.Update(gameTime);
                }
                if(!enemy.IsAlive)
                {
                    enemiesInCurrentWave.Remove(enemy);
                }
            }
            if(enemiesInCurrentWave.Count == 0)
            {
                WaveActive = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Enemy enemy in enemiesInCurrentWave)
            {
                if(WaveActive)
                {
                    enemy.Draw(spriteBatch);
                }
            }
        }
    }
}
