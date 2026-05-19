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

        protected Color[] colors = new Color[]
        {
        Color.Red,
        Color.Orange,
        Color.Yellow,
        Color.Green,
        Color.Cyan,
        Color.Blue,
        Color.Magenta
        };

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            int circleDiameter = 80;

            for (int i = 0; i < 7; i++)
            {
                double angle = -Math.PI * 4 / 2 + (i * Math.PI / 6);
                int centerX = displayWidth / 2;
                int centerY = displayHeight / 2 - 150;
                double radius = Math.Min(displayWidth, displayHeight) / 2.5;

                float circleX = centerX + (float)(Math.Cos(angle) * radius);
                float circleY = centerY + (float)(Math.Sin(angle) * radius);

                float drawX = circleX - circleDiameter / 2;
                float drawY = circleY - circleDiameter / 2;

                using (var pen = new Pen(colors[i], 3))
                {
                    g.DrawEllipse(pen, drawX, drawY, circleDiameter, circleDiameter);
                }
            }
        }

        public static List<ColorChangerPoint> CreateColorChangerPoints(int displayWidth, int displayHeight)
        {
            List<ColorChangerPoint> points = new List<ColorChangerPoint>();

            Color[] colors = new Color[]
            {
                Color.Red, 
                Color.Orange,
                Color.Yellow,
                Color.Green, 
                Color.Cyan, 
                Color.Blue, 
                Color.Magenta
            };

            int centerX = displayWidth / 2;
            int centerY = displayHeight / 2 - 150;
            double radius = Math.Min(displayWidth, displayHeight) / 2.5;
            int circleDiameter = 80;

            for (int i = 0; i < 7; i++)
            {
                double angle = -Math.PI * 4 / 2 + (i * Math.PI / 6);

                float circleX = centerX + (float)(Math.Cos(angle) * radius);
                float circleY = centerY + (float)(Math.Sin(angle) * radius);

                var point = new ColorChangerPoint
                {
                    X = circleX,
                    Y = circleY,
                    TargetColor = colors[i],
                    Radius = circleDiameter / 2,
                    displayWidth = displayWidth,
                    displayHeight = displayHeight
                };

                points.Add(point);
            }

            return points;
        }
    }
}
