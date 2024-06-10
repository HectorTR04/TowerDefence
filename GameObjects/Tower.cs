
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TowerDefence.Base;

namespace TowerDefence.GameObjects
{
    internal abstract class Tower : GameObject
    {
        protected int price;
        protected int damage;
        protected Vector2 position;
        protected float shotCoolDown;
        protected float currentCooldown = 0;
        protected List<Projectile> projectiles;

        public Tower()
        {
            projectiles = new List<Projectile>();
        }
        public void SetRectangle(Rectangle rect)
        {
            Hitbox = rect;
            position = new Vector2(hitbox.X, hitbox.Y);
        }
        public void Update(GameTime gameTime, List<Enemy> enemies)
        {
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile projectile = projectiles[i];
                projectile.Update(gameTime);
                CollisionDetection(projectile, enemies);
            }
            if (currentCooldown <= 0)
            {
                Enemy target = CalculateClosestTarget(enemies);
                if (target != null)
                {
                    FireProjectile(target.Position);
                    currentCooldown = shotCoolDown;
                }
            }
        }
        public abstract void FireProjectile(Vector2 position);  
        protected Enemy CalculateClosestTarget(List<Enemy> enemies)
        {
            Enemy closestEnemy = null;
            float closestDistance = float.MaxValue;

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                float distance = Vector2.Distance(position, enemy.Position);
                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }
            return closestEnemy;
        }
        void CollisionDetection(Projectile projectile, List<Enemy> enemies)
        {
            for (int i = 0;i < enemies.Count;i++)
            {
                if (projectile.Hitbox.Intersects(enemies[i].Hitbox))
                {
                    enemies[i].CurrentHealth -= damage;
                    projectiles.Remove(projectile);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, Hitbox, Color.White);
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile projectile = projectiles[i];
                projectile.Draw(spriteBatch);
            }
        }
    }
}
