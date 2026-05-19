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

        public override void Render(Graphics g)
        {
            int diameter = Radius * 2;

            using (var pen = new Pen(TargetColor, 3))
            {
                g.DrawEllipse(pen, X - diameter / 2, Y - diameter / 2, diameter, diameter);
            }
            var text = GetColorName(TargetColor);
            var font = new Font("Verdana", 10);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using (var brush = new SolidBrush(Color.White))
            {
                g.DrawString(text, font, brush, X, Y, stringFormat);
            }
        }

        private string GetColorName(Color color)
        {
            if (color == Color.Red) return "Красный";
            if (color == Color.Orange) return "Оранжевый";
            if (color == Color.Yellow) return "Жёлтый";
            if (color == Color.Green) return "Зелёный";
            if (color == Color.Cyan) return "Голубой";
            if (color == Color.Blue) return "Синий";
            if (color == Color.Magenta) return "Пурпурный";
            return color.Name;
        }
    }
}
