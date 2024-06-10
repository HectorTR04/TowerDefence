using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using TowerDefence.Base;
using TowerDefence.Managers;
using TowerDefence.ParticleEngine;
using TowerDefence.PathEngine;


namespace TowerDefence.GameObjects
{
    internal class Enemy : GameObject
    {
        protected float curve_speed;
        public float Speed { get { return curve_speed; } }
        public bool IsAlive { get; private set; } = true;
        public int CurrentHealth {  get; set; }
        public Vector2 Position { get; private set; }
        public bool IsSlowed { get; set; } = false;
        public int KillReward { get; protected set; }
        CatmullRomPath cpath_moving;
        float curve_curpos = 0;
        RectangleF healthbar;
        float healthBarHeight = 7;
        GraphicsDevice graphicsDevice;
        bool slowApplied = false;
        protected int maxHealth;
        protected int castleDamage;
        public Enemy(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            healthbar = new RectangleF(hitbox.X, hitbox.Y, CurrentHealth, healthBarHeight);
            float tension_carpath = 1f; 
            cpath_moving = new CatmullRomPath(graphicsDevice, tension_carpath);
            cpath_moving.Clear();
            LoadPath.LoadPathFromFile(cpath_moving, "Path.txt");
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
                healthbar.Width = (CurrentHealth * ((float)CurrentHealth / maxHealth));
                Position = new Vector2(hitbox.X, hitbox.Y);
            }
            if(IsSlowed && !slowApplied) 
            { 
                curve_speed = curve_speed * 0.5f; 
                slowApplied = true; 
            }
            if (CurrentHealth <= 0 || !InPathRange()) 
            { 
                IsAlive = false;
            }
            else if(CurrentHealth <= 0 && InPathRange())
            {
                IsAlive = false;
                GameManager.Instance.PlayerMoney += KillReward;
            }
            if (CurrentHealth > 0 && !InPathRange())
            {
                GameManager.Instance.PlayerHealth -= castleDamage;
            }           
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
                if(!IsSlowed)
                {
                    cpath_moving.DrawMovingObject(curve_curpos, spriteBatch, tex, Color.White);
                }
                else
                {
                    cpath_moving.DrawMovingObject(curve_curpos, spriteBatch, tex, Color.Blue);
                }
                DrawHealthBar(spriteBatch);
            }
        }
        public void DrawHealthBar(SpriteBatch spriteBatch)
        {
            float healthPercentage = (float)CurrentHealth / maxHealth;
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
