using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;
using TowerDefence.GameObjects;
using TowerDefence.Managers;

namespace TowerDefence.Scenes
{
    internal class Gameplay : Scene
    {
        TutorialManager tutorialManager;
        UIManager uiManager;    
        RenderTarget2D renderTarget;
        GraphicsDevice graphicsDevice;
        Path path;
        
        public Gameplay(GraphicsDevice graphicsDevice)
        {
            path = new Path(graphicsDevice);
            this.graphicsDevice = graphicsDevice;
            renderTarget = new RenderTarget2D(graphicsDevice, GlobalValues.ScreenWidth, GlobalValues.ScreenHeight);
            tutorialManager = new TutorialManager();
            uiManager = new UIManager();
        }
        public override void Update(GameTime gameTime)
        {
            if (GameManager.Instance.CurrentRuntimeState == GameManager.RuntimeState.Playing)
            {
                //if (!tutorialManager.TutorialDone)
                //{
                //    tutorialManager.Update(gameTime);
                //}
                uiManager.Update(gameTime);
            }
            else
            {
                return;
            }          
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
            spriteBatch.End();
        }
        void DrawRenderTargetLayer(SpriteBatch spriteBatch)
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(Color.Transparent);
            path.Draw(spriteBatch);
            graphicsDevice.SetRenderTarget(null);
        }
        public bool CanPlace(Tower tower)
        {
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
    }
}
