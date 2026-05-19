using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static particleSystem.Particle;

namespace particleSystem
{
    public class TopEmitter : Emitter
    {
        public int Width; 

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            if (particle is ParticleColorful colorful)
            {
                colorful.FromColor = Color.White;
                colorful.ToColor = Color.FromArgb(0, Color.Black);
            }

            particle.X = Particle.rand.Next(Width); 
            particle.Y = 0; 

            particle.SpeedY = 1; 
            particle.SpeedX = Particle.rand.Next(-2, 2); 
        }
    }
}
