using Microsoft.Xna.Framework;

namespace TowerDefence.Base
{
    internal static class GlobalValues
    {
        public const int ScreenWidth  = 1120;
        public const int ScreenHeight = 800;
        public static readonly Vector2 ScreenCenter = new Vector2(ScreenWidth / 2, ScreenHeight / 2);
        public static readonly Color TextColour = new Color(131,88,53,255);
        public static readonly Color[] ParticleColours = { new Color(154,154,154,255), new Color(112,112,112,255), new Color(69,69,69,255)};
    }
}
