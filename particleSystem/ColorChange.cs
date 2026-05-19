using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static particleSystem.Particle;

namespace particleSystem
{
    public class ColorChangerPoint : ImpactPoint
    {
        public Color TargetColor;  
        public int Radius = 40;   

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius)
            {
                if (particle is Particle.ParticleColorful colorful)
                {
                    colorful.FromColor = TargetColor;
                    colorful.ToColor = TargetColor;
                }
            }
        }

    }
}
