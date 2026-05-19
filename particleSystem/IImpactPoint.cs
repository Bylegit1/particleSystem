using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace particleSystem
{
    public abstract class ImpactPoint
    {
        public float X;
        public float Y;
        public int displayWidth { get; set; } 
        public int displayHeight { get; set; }

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            
        }

   
    }
}
