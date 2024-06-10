using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;
using TowerDefence.GameObjects;
using TowerDefence.Managers;

namespace TowerDefence.Scenes
{
    internal class GameScene : Scene
    {
        TutorialManager tutorialManager;
        UIManager uiManager;
        TowerManager towerManager;
        EnemyManager enemyManager;
        RenderTarget2D renderTarget;
        public GraphicsDevice graphicsDevice;
        Path path;
        #region Border Rectangles
        Rectangle northBorder = new Rectangle(0, 0, GlobalValues.ScreenWidth, GlobalValues.ScreenHeight / 4);
        Rectangle southBorder = new Rectangle(0, GlobalValues.ScreenHeight - GlobalValues.ScreenHeight / 4, GlobalValues.ScreenWidth, GlobalValues.ScreenHeight / 4);
        Rectangle eastBorder = new Rectangle(GlobalValues.ScreenWidth - GlobalValues.ScreenWidth / 4, 0, GlobalValues.ScreenWidth / 4, GlobalValues.ScreenHeight);
        Rectangle westBorder = new Rectangle(0, 0, GlobalValues.ScreenWidth / 6, GlobalValues.ScreenHeight);
        #endregion
        Rectangle[] borders;
        Texture2D borderTexture;
        
        public GameScene(GraphicsDevice graphicsDevice)
        {
            path = new Path(graphicsDevice);
            this.graphicsDevice = graphicsDevice;
            borderTexture = new Texture2D(graphicsDevice, 1, 1);
            borderTexture.SetData(new[] { new Color(255, 0, 0, 50) });
            borders = new Rectangle[] { northBorder, southBorder, eastBorder, westBorder };
            renderTarget = new RenderTarget2D(graphicsDevice, GlobalValues.ScreenWidth, GlobalValues.ScreenHeight);
            tutorialManager = new TutorialManager();
            enemyManager = new EnemyManager(graphicsDevice);
            towerManager = new TowerManager(this, enemyManager);
            uiManager = new UIManager(enemyManager, towerManager);
        }
        public override void Update(GameTime gameTime)
        {
            if (GameManager.Instance.CurrentRuntimeState == GameManager.RuntimeState.Playing)
            {
                //if (!tutorialManager.TutorialDone)
                //{
                //    tutorialManager.Update(gameTime);
                //}
                uiManager.Update();
                towerManager.Update(gameTime);
                enemyManager.Update(gameTime);
            }
            else
            {
                return;
            }  
            if(GameManager.Instance.PlayerHealth <= 0) { GameManager.Instance.Exit = true; }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawRenderTargetLayer(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.Draw(AssetManager.GameMap, Vector2.Zero, Color.White);
            //if (!tutorialManager.TutorialDone)
            //{
            //    tutorialManager.Draw(spriteBatch);
            //}
            uiManager.Draw(spriteBatch);
            spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            enemyManager.Draw(spriteBatch);
            spriteBatch.End();
        }
        public void DrawRenderTargetLayer(SpriteBatch spriteBatch)
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            towerManager.Draw(spriteBatch);
            path.Draw(spriteBatch);
            //DrawBorders(spriteBatch);
            spriteBatch.End();
            graphicsDevice.SetRenderTarget(null);
        }
        public bool CanPlace(Tower tower)
        {
            foreach(Rectangle border in borders)
            {
                if (tower.Hitbox.Intersects(border))
                {
                    return false;
                }
            }

            if(tower.Price > GameManager.Instance.PlayerMoney) { return false; }

            Color[] pixels = new Color[tower.Tex.Width * tower.Tex.Height];
            Color[] pixels2 = new Color[tower.Tex.Width * tower.Tex.Height];
            tower.Tex.GetData<Color>(pixels2);
            renderTarget.GetData(0, tower.Hitbox, pixels, 0, pixels.Length);
            for (int i = 0; i < pixels.Length; ++i)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                    return false;
            }
            return true;
        }
        void DrawBorders(SpriteBatch spriteBatch)
        {
            if(towerManager.IsPlacingTower)
            {
                foreach(Rectangle border in borders)
                {
                    spriteBatch.Draw(borderTexture, border, Color.White);
                }
            }
        }
    }
}
