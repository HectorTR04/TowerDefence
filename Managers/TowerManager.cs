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
        bool IsPlacingTower = true;
        GameScene gameScene;
        public TowerManager(GameScene gameScene)
        {
            this.gameScene = gameScene;
            towerList = new List<Tower>();
        }

        void AddTower(Vector2 position)
        {
            ArcherTower tower = new ArcherTower();
            Rectangle towerRect = new Rectangle((int)position.X, (int)position.Y, tower.Tex.Width, tower.Tex.Height);
            tower.SetRectangle(towerRect);

            gameScene.DrawRenderTargetLayer(new SpriteBatch(gameScene.graphicsDevice));

            if (gameScene.CanPlace(tower))
            {
                towerList.Add(tower);
            }
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
                tower.Update(gameTime);
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
