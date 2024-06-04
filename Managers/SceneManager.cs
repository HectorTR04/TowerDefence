using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Scenes;

namespace TowerDefence.Managers
{
    internal class SceneManager
    {
        MainMenu mainMenu;
        Gameplay gamePlay;

        public SceneManager(GraphicsDevice graphicsDevice)
        {
            mainMenu = new MainMenu();
            gamePlay = new Gameplay(graphicsDevice);
        }
        public void Update(GameTime gameTime)
        {
            switch (GameManager.Instance.CurrentScene)
            {
                case GameManager.Scene.MainMenu:
                    mainMenu.Update(gameTime);
                    break;
                case GameManager.Scene.Gameplay: 
                    gamePlay.Update(gameTime);
                    break;
            }         
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (GameManager.Instance.CurrentScene)
            {
                case GameManager.Scene.MainMenu:
                    spriteBatch.Begin();
                    mainMenu.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameManager.Scene.Gameplay:
                    gamePlay.Draw(spriteBatch);
                    break;
            }
        }
    }
}
