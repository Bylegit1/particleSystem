using System;
using System.Collections.Generic;
using System.Drawing;

namespace particleSystem
{
    public class RadarPoint : ImpactPoint
    {
        public int sizeRadar = 100;           
        public int insideCount = 0;      
        public Color radarColor = Color.LimeGreen;  

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            bool isInside = distance < sizeRadar / 2;

            if (isInside)
            {
                particle.IsParticleInRadar = true;

                if (particle is Particle.ParticleColorful colorful)
                {
                    colorful.FromColor = radarColor;
                    colorful.ToColor = radarColor;
                }
            }
            else
            {
                if (particle.IsParticleInRadar)
                {
                    particle.IsParticleInRadar = false;

                    if (particle is Particle.ParticleColorful colorful)
                    {
                        colorful.FromColor = Color.White;
                        colorful.ToColor = Color.FromArgb(0, Color.Black);
                    }
                }
            }
        }

        public void UpdateCount(List<Particle> particles)
        {
            insideCount = 0;
            foreach (var particle in particles)
            {
                float dx = X - particle.X;
                float dy = Y - particle.Y;
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distance < sizeRadar / 2)
                {
                    insideCount++;
                }
            }
        }

        public void ChangeSize(int delta)
        {
            int newSize = sizeRadar + delta;
            if (newSize >= 50 && newSize <= 300)
            {
                sizeRadar = newSize;
            }
        }

        public override void Render(Graphics g)
        {
            int radius = sizeRadar / 2;

            using (var pen = new Pen(radarColor, 3))
            {
                g.DrawEllipse(pen, X - radius, Y - radius, sizeRadar, sizeRadar);
            }

            string counterText = insideCount.ToString();
            using (var brush = new SolidBrush(Color.White))
            {
                var font = new Font("Verdana", 14, FontStyle.Bold);
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