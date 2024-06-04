using Microsoft.Xna.Framework;
using TowerDefence.Base;
using TowerDefence.GameObjects.UI;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Managers
{
    internal class TutorialManager
    {
        Message[] tutorialMessages;
        Rectangle tutorialMessageRect;
        Button confirm;
        Rectangle confirmButtonRect;
        public bool TutorialDone {  get; private set; }
        string[] tutorialTexts;
        int tutorialIndex;
        public TutorialManager()
        {
            TutorialDone = false;
            tutorialTexts = new string[] { GlobalStrings.TUTORIALMSG1, GlobalStrings.TUTORIALMSG2, GlobalStrings.TUTORIALMSG3 };
            CenterMessages();
            #region Ridiculous Rectangle
            confirmButtonRect
                = new Rectangle(tutorialMessageRect.X + (tutorialMessageRect.Width / 2),
                tutorialMessageRect.Y + (tutorialMessageRect.Height / 2) + (tutorialMessageRect.Height / 6),
                AssetManager.ConfirmButton.Width, AssetManager.ConfirmButton.Height);
            #endregion
            confirm = new Button(confirmButtonRect, TutorialTransition);
            tutorialMessages = new Message[3];
            for (int i = 0; i < tutorialTexts.Length; i++)
            {
                tutorialMessages[i] = new Message(AssetManager.TutorialMessage, tutorialTexts[i], tutorialMessageRect);
            }
            tutorialMessages[0].DisplayMessage = true;
        }
        public void Update(GameTime gameTime)
        {
            foreach (Message message in tutorialMessages)
            {
                if (message.DisplayMessage)
                {
                    message.Update(gameTime);
                }
            }
            confirm.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Message message in tutorialMessages)
            {
                if (message.DisplayMessage)
                {
                    message.Draw(spriteBatch);
                }
            }
            spriteBatch.Draw(AssetManager.ConfirmButton, confirmButtonRect, Color.White);        
        }
        void TutorialTransition()
        {
            tutorialIndex++;
            if (tutorialIndex < tutorialMessages.Length)
            {
                tutorialMessages[tutorialIndex - 1].DisplayMessage = false;
                tutorialMessages[tutorialIndex].DisplayMessage = true;
            }
            else
            {
                TutorialDone = true;
            }
        }
        void CenterMessages()
        {
            Vector2 screenCenter = GlobalValues.ScreenCenter;

            int rectWidth = AssetManager.TutorialMessage.Width;
            int rectHeight = AssetManager.TutorialMessage.Height;

            int rectX = (int)(screenCenter.X - rectWidth / 2);
            int rectY = (int)(screenCenter.Y - rectHeight / 2);
            tutorialMessageRect = new Rectangle(rectX, rectY, rectWidth, rectHeight);
        }
    }
}
