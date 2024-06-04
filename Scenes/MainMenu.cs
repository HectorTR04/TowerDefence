using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;
using TowerDefence.GameObjects.UI;
using TowerDefence.Managers;

namespace TowerDefence.Scenes
{
    internal class MainMenu : Scene
    {
        Button startButton;
        Rectangle startButtonRectangle;
        Button quitButton;
        Rectangle quitButtonRectangle;
            
        public MainMenu()
        {
            startButtonRectangle = new Rectangle(486, 555, AssetManager.StartButton.Width, AssetManager.StartButton.Height);
            startButton = new Button(startButtonRectangle, StartGame);
            quitButtonRectangle = new Rectangle(486, 605, AssetManager.StartButton.Width, AssetManager.StartButton.Height);
            quitButton = new Button(quitButtonRectangle, QuitGame);
        }
        public override void Update(GameTime gameTime)
        {
            startButton.Update();
            quitButton.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.MenuBackground, Vector2.Zero, Color.White);
            spriteBatch.Draw(AssetManager.StartButton, startButton.Hitbox, Color.White);
            spriteBatch.Draw(AssetManager.QuitButton, quitButton.Hitbox, Color.White);
        }
        void StartGame()
        {
            GameManager.Instance.CurrentScene = GameManager.Scene.Gameplay;
        }
        void QuitGame()
        {
            GameManager.Instance.Exit = true;
        }
    }
}
