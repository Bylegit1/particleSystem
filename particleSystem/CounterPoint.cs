using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace particleSystem
{
    public class CounterPoint : ImpactPoint
    {
        public int Radius = 40;           
        public int CountParticles = 0;    
        private Color pointColor = Color.Red;  

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius)
            {
                CountParticles++;
                particle.Life = 0;
            }
        }

        public override void Render(Graphics g)
        {
            int diameter = Radius * 2;

            using (var pen = new Pen(Color.Red, 3))
            {
                g.DrawEllipse(pen, X - diameter / 2, Y - diameter / 2, diameter, diameter);
            }

            using (var brush = new SolidBrush(Color.FromArgb(80, pointColor)))
            {
                g.FillEllipse(brush, X - diameter / 2, Y - diameter / 2, diameter, diameter);
            }

            string counterText = CountParticles.ToString();
            using (var brush = new SolidBrush(Color.Gold))
            {
                var font = new Font("Verdana", 16, FontStyle.Bold);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                g.DrawString(counterText, font, brush, X, Y, format);
            }
        }
    }
}
