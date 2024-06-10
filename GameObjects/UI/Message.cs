using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Base;
using TowerDefence.Managers;

namespace TowerDefence.GameObjects.UI
{
    internal class Message : UIObject
    {
        public bool DisplayMessage;
        string text;
        Rectangle position;
        string parsedText;
        string typedText;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        int borderPadding = 10;

        public Message(Texture2D texture, string text, Rectangle position) : base(position)
        {
            tex = texture;
            this.text = text;
            this.position = position;
            DisplayMessage = false;
            parsedText = parseText(text);
            typedText = string.Empty;
            delayInMilliseconds = 50;
            isDoneDrawing = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!isDoneDrawing)
            {
                if (delayInMilliseconds == 0)
                {
                    typedText = parsedText;
                    isDoneDrawing = true;
                }
                else if (typedTextLength < parsedText.Length)
                {
                    typedTextLength = typedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / delayInMilliseconds;

                    if (typedTextLength >= parsedText.Length)
                    {
                        typedTextLength = parsedText.Length;
                        isDoneDrawing = true;
                    }

                    typedText = parsedText.Substring(0, (int)typedTextLength);
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = AssetManager.defaultFont.MeasureString(text);
            Vector2 textPosition = new Vector2(
                position.X + borderPadding,
                position.Y + borderPadding
            );
            if (DisplayMessage)
            {
                spriteBatch.Draw(tex, position, Color.White);
                spriteBatch.DrawString(AssetManager.defaultFont, typedText, textPosition, GlobalValues.TextColour);
            }
        }

        string parseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                if (AssetManager.defaultFont.MeasureString(line + word).Length() > tex.Width)
                {
                    returnString = returnString + line + '\n';
                    line = string.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
        }
    }
}

