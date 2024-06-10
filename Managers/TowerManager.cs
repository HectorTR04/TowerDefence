using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TowerDefence.GameObjects;
using TowerDefence.Scenes;

namespace TowerDefence.Managers
{
    internal class TowerManager
    {
        List<Tower> towerList;
        bool isPlacingTower = true;
        public bool IsPlacingTower
        {
            get { return isPlacingTower; }
        }
        public enum TowerType { Archer, Mage}
        public TowerType CurrentTowerSelected { get; set; }
        GameScene gameScene;
        EnemyManager enemyManager;
        public TowerManager(GameScene gameScene, EnemyManager enemyManager)
        {
            this.gameScene = gameScene;
            towerList = new List<Tower>();
            this.enemyManager = enemyManager;
        }

        void AddTower(Vector2 position)
        {
            Tower tower = null;
            switch (CurrentTowerSelected)
            {
                case TowerType.Mage:
                    MageTower mageTower = new MageTower();
                    Rectangle mageTowerRect = new Rectangle((int)position.X, (int)position.Y, mageTower.Tex.Width, mageTower.Tex.Height);
                    mageTower.SetRectangle(mageTowerRect);
                    tower = mageTower;
                    break;
                case TowerType.Archer:
                    ArcherTower archerTower = new ArcherTower();
                    Rectangle archerTowerRect = new Rectangle((int)position.X, (int)position.Y, archerTower.Tex.Width, archerTower.Tex.Height);
                    archerTower.SetRectangle(archerTowerRect);
                    tower = archerTower; 
                    break;
            }
            if (tower != null && gameScene.CanPlace(tower)) 
            {
                towerList.Add(tower);
            }
            gameScene.DrawRenderTargetLayer(new SpriteBatch(gameScene.graphicsDevice));          
        }
        public void Update(GameTime gameTime)
        {
            if(IsPlacingTower)
            {
                Vector2 placementPosition = new Vector2(KeyMouseManager.mouseState.X, KeyMouseManager.mouseState.Y);
                if(KeyMouseManager.RightClick())
                {
                    AddTower(placementPosition);
                }
            }
            foreach (Tower tower in towerList)
            {
                tower.Update(gameTime, enemyManager.EnemiesInCurrentWave);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tower tower in towerList)
            {
                tower.Draw(spriteBatch);
            }
        }

       
    }
}
