using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using TowerDefence.Base;
using TowerDefence.Managers;

namespace TowerDefence
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SceneManager sceneManager;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = GlobalValues.ScreenWidth;
            graphics.PreferredBackBufferHeight = GlobalValues.ScreenHeight;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            AssetManager.LoadSprites(Content);
            sceneManager = new SceneManager(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameManager.Instance.Exit)
                Exit();
            KeyMouseManager.Update();
            sceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            sceneManager.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}