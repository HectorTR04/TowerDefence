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
        protected float curve_speed;
        public float Speed { get { return curve_speed; } }
        public bool IsAlive { get; private set; } = true;
        RectangleF healthbar;
        float healthBarHeight = 7;
        GraphicsDevice graphicsDevice;
        protected int currentHealth;
        protected int maxHealth;
        public Vector2 Position { get; private set; }

        public Enemy(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            healthbar = new RectangleF(hitbox.X, hitbox.Y, currentHealth, healthBarHeight);
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
            if (InPathRange())
            {
                Vector2 vec = cpath_moving.EvaluateAt(curve_curpos);
                hitbox.X = (int)vec.X;
                hitbox.Y = (int)vec.Y;
                healthbar.X = hitbox.X - 10;
                healthbar.Y = hitbox.Y - 20;
                healthbar.Width = (currentHealth * ((float)currentHealth / maxHealth)) * 2;
                Position = new Vector2(hitbox.X, hitbox.Y);
            }
            if (currentHealth == 0 || !InPathRange()) { IsAlive = false; }
        }
        bool InPathRange()
        {
            if(curve_curpos < 1 & curve_curpos > 0) { return true; }
            return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive && InPathRange())
            {
                cpath_moving.DrawMovingObject(curve_curpos, spriteBatch, tex);
                DrawHealthBar(spriteBatch);
            }
        }
        public void DrawHealthBar(SpriteBatch spriteBatch)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            Color healthBarColour;
            if (healthPercentage > 0.5f)
            {
                healthBarColour = Color.Green;
            }
            else if (healthPercentage > 0.25f && healthPercentage < 0.5f)
            {
                healthBarColour = Color.Yellow;
            }
            else
            {
                healthBarColour = Color.Red;
            }
            spriteBatch.FillRectangle(healthbar, healthBarColour, 0f);
        }
    }
}
