using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.ParticleEngine
{
    public class ParticleSystem
    {
        Random random;
        public Vector2 EmitterLocation { get; set; }
        List<Particle> particles;
        Texture2D texture;
        Color color;
        Color[] colors;
        Point direction;
        public ParticleSystem(Texture2D texture, Vector2 location, Color[] colors, Point direction)
        {
            EmitterLocation = location;
            this.particles = new List<Particle>();
            this.texture = texture;
            random = new Random();
            this.colors = colors;
            this.direction = direction;
        }
        Particle GenerateNewParticle()
        {
            Vector2 position = EmitterLocation;
            int ttl = random.Next(15);
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            int randomIndex = random.Next(0, colors.Length);
            color = colors[randomIndex];

           Vector2 originalVelocity = new Vector2(
           5f * (float)(random.NextDouble() * direction.X),
           (random.Next(2, 5) * direction.Y));

            float variationAmount = 1.5f; 
            Vector2 velocity = new Vector2(
                originalVelocity.X + (float)(random.NextDouble() * 2 - 1) * variationAmount,
                originalVelocity.Y + (float)(random.NextDouble() * 2 - 1) * variationAmount
            );

            float size = random.Next(2, 3);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }
        public void Update()
        {
            int total = 1;

            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].LifeSpan <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }
    }
}
