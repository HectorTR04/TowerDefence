using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using TowerDefence.GameObjects.UI;

namespace TowerDefence.Managers
{
    internal class UIManager
    {
        Button pauseButton, shopButton, startWaveButton, exitButton;
        Rectangle pauseRect, shopRect, startWaveRect, exitRect;
        const int buttonWidth = 32;
        const int buttonDistance = 16;
        const int firstButtonX = 32;
        const int firstButtonY = 48;
        PauseMenu pauseMenu;

        public UIManager()
        {
            pauseMenu = new PauseMenu();
            exitRect = new Rectangle(firstButtonX, firstButtonY, buttonWidth, buttonWidth);
            pauseRect = new Rectangle(firstButtonX + buttonWidth + buttonDistance, firstButtonY, buttonWidth, buttonWidth);
            shopRect = new Rectangle(firstButtonX + 2 * (buttonWidth + buttonDistance), firstButtonY, buttonWidth, buttonWidth);
            startWaveRect = new Rectangle(firstButtonX + 3 * (buttonWidth + buttonDistance), firstButtonY, buttonWidth, buttonWidth);

            pauseButton = new Button(pauseRect, Pause);
            shopButton = new Button(shopRect, OpenShop);
            startWaveButton = new Button(startWaveRect, StartWave);
            exitButton = new Button(exitRect, Exit);
        }
        public void Update(GameTime gameTime)
        {
            pauseButton.Update();
            shopButton.Update();
            startWaveButton.Update();
            exitButton.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.UIBackground, Vector2.Zero, Color.White);
        }
        void Pause()
        {
            GameManager.Instance.CurrentRuntimeState = GameManager.RuntimeState.Paused;
            pauseMenu.ShowDialog();
        }
        void StartWave()
        {
            Debug.WriteLine("startwave pressed");
        }
        void OpenShop()
        {
            Debug.WriteLine("open shop");
        }
        void Exit()
        {
            GameManager.Instance.Exit = true;
        }
    }
}
