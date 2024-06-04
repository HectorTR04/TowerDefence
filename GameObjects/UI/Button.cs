using Microsoft.Xna.Framework;
using TowerDefence.Base;
using TowerDefence.Managers;


namespace TowerDefence.GameObjects.UI
{

    internal class Button : GameObject
    {
        public delegate void ButtonAction();

        ButtonAction onClickAction;
        const float HoverScaleFactor = 1.05f;
        Vector2 originalSize;
        Vector2 maximumSize;

        public Button(Rectangle rect, ButtonAction onClick) : base(rect)
        {
            hitbox = rect;
            onClickAction = onClick;
            originalSize = new Vector2(rect.Width, rect.Height);
            maximumSize = new Vector2(rect.Width * 1.5f, rect.Height * 1.5f);
        }
        public void Update()
        {
            Point mousePosition = new Point(KeyMouseManager.mouseState.X, KeyMouseManager.mouseState.Y);
            if (hitbox.Contains(mousePosition) && KeyMouseManager.LeftClick())
            {
                OnClick();
            }
        }
        public void OnClick()
        {
            onClickAction?.Invoke();
        }
    }
}
