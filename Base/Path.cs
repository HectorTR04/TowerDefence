using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Managers;
using TowerDefence.PathEngine;

namespace TowerDefence.Base
{
    internal class Path
    {
        CatmullRomPath cpath_road;
        public static int LevelNr;

        GraphicsDevice graphicsDevice;

        public Path(GraphicsDevice graphicsDevice)
        {
            LevelNr += 1;
            this.graphicsDevice = graphicsDevice;
            float tension_road = 0.5f; // 0 = sharp turns, 0.5 = moderate turns, 1 = soft turns
            cpath_road = new CatmullRomPath(graphicsDevice, tension_road);

            cpath_road.Clear();
            LoadPath.LoadPathFromFile(cpath_road, "Path.txt");
         
            cpath_road.DrawFillSetup(graphicsDevice, 15, 1, 26);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            cpath_road.DrawFill(graphicsDevice, AssetManager.Path);         
        }
    }
}
