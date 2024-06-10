using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TowerDefence.GameObjects;
using TowerDefence.GameObjects.Enemies;

namespace TowerDefence.Managers
{
    internal class EnemyManager
    {
        Random random;
        public List<Enemy> EnemiesInCurrentWave { get; private set; }
        GraphicsDevice graphicsDevice;
        int timeSinceLastSpawn = 0;
        int millisecondsBetweenCreation = 3000;
        int enemiesToSpawn = 1;
        int enemiesSpawned;
        
        public EnemyManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            random = new Random();
            EnemiesInCurrentWave = new List<Enemy>();
        }
        public void LoadWave(GameTime gameTime)
        {
            timeSinceLastSpawn += gameTime.ElapsedGameTime.Milliseconds;
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                if (timeSinceLastSpawn > millisecondsBetweenCreation)
                {
                    timeSinceLastSpawn -= millisecondsBetweenCreation;
                    int randomEnemyType = random.Next(0,2);
                    if(randomEnemyType == 0)
                    {
                        Enemy newEnemy = new Goblin(graphicsDevice);
                        EnemiesInCurrentWave.Add(newEnemy);
                        enemiesSpawned++;
                    }
                    else
                    {
                        Enemy newEnemy = new Orc(graphicsDevice);
                        EnemiesInCurrentWave.Add(newEnemy);
                        enemiesSpawned++;
                    }
                }
            }
            if (GameManager.Instance.StartWave && enemiesSpawned == enemiesToSpawn)
            {
                GameManager.Instance.StartWave = false;
                enemiesSpawned = 0;
            }
        }
        public void Update(GameTime gameTime)
        {
            if(GameManager.Instance.StartWave)
            {
                LoadWave(gameTime);
            }
            for (int i = EnemiesInCurrentWave.Count - 1; i >= 0; i--)
            {
                Enemy enemy = EnemiesInCurrentWave[i];
                if (enemy.IsAlive)
                {
                    enemy.Update(gameTime);
                }
                else
                {
                    EnemiesInCurrentWave.RemoveAt(i);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = EnemiesInCurrentWave.Count - 1; i >= 0; i--)
            {
                Enemy enemy = EnemiesInCurrentWave[i];
                if (enemy.IsAlive)
                {
                    enemy.Draw(spriteBatch);
                }
            }
        }
    }
}
