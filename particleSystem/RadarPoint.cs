using System;
using System.Collections.Generic;
using System.Drawing;

namespace particleSystem
{
    public class RadarPoint : ImpactPoint
    {
        public int sizeRadar = 100;
        public Color radarColor = Color.Lime;

        private List<Particle> insideParticles = new List<Particle>();

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            bool isInside = distance + particle.Radius < sizeRadar / 2;

            if (isInside)
            {
                if (!insideParticles.Contains(particle))
                {
                    insideParticles.Add(particle);
                }
            }
            else
            {
                if (insideParticles.Contains(particle))
                {
                    insideParticles.Remove(particle);
                }
            }
        }

        public override void Render(Graphics g)
        {
            foreach (var particle in insideParticles)
            {
                float k = Math.Min(1f, particle.Life / 100);
                Color color = Particle.ParticleColorful.MixColor(radarColor, radarColor, k);

                using (var brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush,
                        particle.X - particle.Radius,
                        particle.Y - particle.Radius,
                        particle.Radius * 2,
                        particle.Radius * 2);
                }
            }

            int radius = sizeRadar / 2;
            using (var pen = new Pen(radarColor, 3))
            {
                g.DrawEllipse(pen, X - radius, Y - radius, sizeRadar, sizeRadar);
            }

            string counterText = insideParticles.Count.ToString();
            using (var font = new Font("Verdana", 10))
            {
                var stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var size = g.MeasureString(counterText, font);

                using (var textBrush = new SolidBrush(Color.Lime))
                {
                    g.DrawString(counterText, font, textBrush, X, Y, stringFormat);
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
    }
}