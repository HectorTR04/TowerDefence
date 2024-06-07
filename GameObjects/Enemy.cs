using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using TowerDefence.Base;
using TowerDefence.Managers;
using TowerDefence.PathEngine;


namespace TowerDefence.GameObjects
{
    internal class Enemy : GameObject
    {
        CatmullRomPath cpath_moving;
        float curve_curpos = 0;
        float curve_speed = 0.1f;
        public float Speed { get { return curve_speed; } }
        RectangleF healthbar;
        float healthBarWidth = 10;
        float healthBarHeight = 5;
        GraphicsDevice graphicsDevice;
        

        public Enemy(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            healthbar = new RectangleF(hitbox.X, hitbox.Y, healthBarWidth, healthBarHeight);
            float tension_carpath = 1f; // 0 = sharp turns, 0.5 = moderate turns, 1 = soft turns
            cpath_moving = new CatmullRomPath(graphicsDevice, tension_carpath);

            cpath_moving.Clear();
            LoadPath.LoadPathFromFile(cpath_moving, "Path.txt");

            // DrawFillSetup must be called (once) for every path that uses DrawFill
            // Call again if curve is altered or if window is resized
            cpath_moving.DrawFillSetup(graphicsDevice, 15, 1, 256);
        }
        public void Update(GameTime gameTime)
        {
            curve_curpos += curve_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (curve_curpos < 1 & curve_curpos > 0)
            {
                Vector2 vec = cpath_moving.EvaluateAt(curve_curpos);
                hitbox.X = (int)vec.X;
                hitbox.Y = (int)vec.Y;
                healthbar.X = hitbox.X;
                healthbar.Y = hitbox.Y - 20;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (curve_curpos < 1 & curve_curpos > 0)
            {
                cpath_moving.DrawMovingObject(curve_curpos, spriteBatch, tex);
                DrawHealthBar(spriteBatch);
            }

        }
        public void DrawHealthBar(SpriteBatch spriteBatch)
        {
            spriteBatch.FillRectangle(healthbar, Color.Red, 0f);
        }
    }
}
