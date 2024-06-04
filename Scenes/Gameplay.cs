using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;
using TowerDefence.Managers;

namespace TowerDefence.Scenes
{
    internal class Gameplay : Scene
    {
        TutorialManager tutorialManager;
        UIManager uiManager;    
        RenderTarget2D renderTarget;
        GraphicsDevice graphicsDevice;
        Wave wave;
        
        public Gameplay(GraphicsDevice graphicsDevice)
        {
            wave = new Wave(graphicsDevice);
            this.graphicsDevice = graphicsDevice;
            renderTarget = new RenderTarget2D(graphicsDevice, GlobalValues.ScreenWidth, GlobalValues.ScreenHeight);
            tutorialManager = new TutorialManager();
            uiManager = new UIManager();
        }
        public override void Update(GameTime gameTime)
        {
            if (GameManager.Instance.CurrentRuntimeState == GameManager.RuntimeState.Playing)
            {
                if (!tutorialManager.TutorialDone)
                {
                    tutorialManager.Update(gameTime);
                }
                uiManager.Update(gameTime);
            }
            else
            {
                return;
            }          
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(AssetManager.GameMap, Vector2.Zero, Color.White);
            if (!tutorialManager.TutorialDone)
            {
                tutorialManager.Draw(spriteBatch);
            }
            uiManager.Draw(spriteBatch);
            DrawRenderTargetLayer(spriteBatch);
            spriteBatch.End();
        }
        void DrawRenderTargetLayer(SpriteBatch spriteBatch)
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(Color.Transparent);
            wave.Draw(spriteBatch); 
            spriteBatch.Draw(AssetManager.Path, Vector2.Zero, Color.White);
            graphicsDevice.SetRenderTarget(null);
        }
    }
}
