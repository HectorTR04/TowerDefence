using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Managers;
using TowerDefence.PathEngine;

namespace TowerDefence.Base
{
    internal class Path
    {
        /// Catmull-Rom path
        CatmullRomPath cpath_road;
        CatmullRomPath cpath_moving;
        public static int LevelNr;

        // Current location along the curve (car).
        // 0 and 1 is at the first and last control point, respectively.
        float curve_curpos = 0;
        // How fast to go along the curve = fraction of curve / second
        float curve_speed = 0.2f;

        GraphicsDevice graphicsDevice;

        public Path(GraphicsDevice graphicsDevice)
        {
            LevelNr += 1;
            this.graphicsDevice = graphicsDevice;
            float tension_road = 0.5f; // 0 = sharp turns, 0.5 = moderate turns, 1 = soft turns
            cpath_road = new CatmullRomPath(graphicsDevice, tension_road);

            //float tension_carpath = 0.5f; // 0 = sharp turns, 0.5 = moderate turns, 1 = soft turns
            //cpath_moving = new CatmullRomPath(graphicsDevice, tension_carpath);



            cpath_road.Clear();
            //LoadPathFromFile(cpath_road, "spiral.txt");
            LoadPath.LoadPathFromFile(cpath_road, "Path.txt");

            //cpath_moving.Clear();
            //LoadPath.LoadPathFromFile(cpath_moving, "Path.txt");

            // DrawFillSetup must be called (once) for every path that uses DrawFill
            // Call again if curve is altered or if window is resized
            cpath_road.DrawFillSetup(graphicsDevice, 15, 1, 26);
            //cpath_moving.DrawFillSetup(gd, 2, 1, 256);
        }

        public void Update(GameTime gameTime)
        {
            // Step our location forward along the curve forward
            //curve_curpos += curve_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //// Reset if we reach the end
            //if (curve_curpos > 1.0f) curve_curpos = 0.0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw filled paths
            cpath_road.DrawFill(graphicsDevice, AssetManager.Path);
            //cpath_moving.DrawFill(gd, TextureHandler.texture_red);

            // Draw control points
            //cpath_road.DrawPoints(spriteBatch, Color.Black, 6);
            //cpath_moving.DrawPoints(spriteBatch, Color.Blue, 6);

            //cpath_moving.DrawMovingObject(curve_curpos, spriteBatch, AssetManager.QuitButton);
        }
    }
}
