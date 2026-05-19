using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static particleSystem.Particle;

namespace particleSystem
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        ColorChangerPoint redPoint;
        ColorChangerPoint orangePoint;
        ColorChangerPoint yellowPoint;
        ColorChangerPoint greenPoint;
        ColorChangerPoint cyanPoint;
        ColorChangerPoint bluePoint;
        ColorChangerPoint magentaPoint;

        private bool isMovingRed = false;
        private bool isMovingOrange = false;
        private bool isMovingYellow = false;
        private bool isMovingGreen = false;
        private bool isMovingCyan = false;
        private bool isMovingBlue = false;
        private bool isMovingMagenta = false;

        private float offsetX, offsetY;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            int centerX = picDisplay.Width / 2;
            int centerY = picDisplay.Height / 2 - 150;
            double radius = Math.Min(picDisplay.Width, picDisplay.Height) / 2.5;
            int circleDiameter = 80;
            int circleRadius = circleDiameter / 2;

            redPoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (0 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (0 * Math.PI / 6)) * radius),
                TargetColor = Color.Red,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            orangePoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (1 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (1 * Math.PI / 6)) * radius),
                TargetColor = Color.Orange,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            yellowPoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (2 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (2 * Math.PI / 6)) * radius),
                TargetColor = Color.Yellow,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            greenPoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (3 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (3 * Math.PI / 6)) * radius),
                TargetColor = Color.Green,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            cyanPoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (4 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (4 * Math.PI / 6)) * radius),
                TargetColor = Color.Cyan,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            bluePoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (5 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (5 * Math.PI / 6)) * radius),
                TargetColor = Color.Blue,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            magentaPoint = new ColorChangerPoint
            {
                X = centerX + (float)(Math.Cos(-Math.PI * 4 / 2 + (6 * Math.PI / 6)) * radius),
                Y = centerY + (float)(Math.Sin(-Math.PI * 4 / 2 + (6 * Math.PI / 6)) * radius),
                TargetColor = Color.Magenta,
                Radius = circleRadius,
                displayWidth = picDisplay.Width,
                displayHeight = picDisplay.Height
            };

            emitter.impactPoints.Add(redPoint);
            emitter.impactPoints.Add(orangePoint);
            emitter.impactPoints.Add(yellowPoint);
            emitter.impactPoints.Add(greenPoint);
            emitter.impactPoints.Add(cyanPoint);
            emitter.impactPoints.Add(bluePoint);
            emitter.impactPoints.Add(magentaPoint);

            emitters.Add(emitter);

            picDisplay.MouseDown += PicDisplay_MouseDown;
            picDisplay.MouseMove += PicDisplay_MouseMove;
            picDisplay.MouseUp += PicDisplay_MouseUp;
        }


        private void PicDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            isMovingRed = isMovingOrange = isMovingYellow = isMovingGreen =
            isMovingCyan = isMovingBlue = isMovingMagenta = false;

            if (IsPointClicked(redPoint, e.X, e.Y))
            {
                isMovingRed = true;
                offsetX = redPoint.X - e.X;
                offsetY = redPoint.Y - e.Y;
            }
            else if (IsPointClicked(orangePoint, e.X, e.Y))
            {
                isMovingOrange = true;
                offsetX = orangePoint.X - e.X;
                offsetY = orangePoint.Y - e.Y;
            }
            else if (IsPointClicked(yellowPoint, e.X, e.Y))
            {
                isMovingYellow = true;
                offsetX = yellowPoint.X - e.X;
                offsetY = yellowPoint.Y - e.Y;
            }
            else if (IsPointClicked(greenPoint, e.X, e.Y))
            {
                isMovingGreen = true;
                offsetX = greenPoint.X - e.X;
                offsetY = greenPoint.Y - e.Y;
            }
            else if (IsPointClicked(cyanPoint, e.X, e.Y))
            {
                isMovingCyan = true;
                offsetX = cyanPoint.X - e.X;
                offsetY = cyanPoint.Y - e.Y;
            }
            else if (IsPointClicked(bluePoint, e.X, e.Y))
            {
                isMovingBlue = true;
                offsetX = bluePoint.X - e.X;
                offsetY = bluePoint.Y - e.Y;
            }
            else if (IsPointClicked(magentaPoint, e.X, e.Y))
            {
                isMovingMagenta = true;
                offsetX = magentaPoint.X - e.X;
                offsetY = magentaPoint.Y - e.Y;
            }
        }

        private bool IsPointClicked(ColorChangerPoint point, int clickX, int clickY)
        {
            if (point == null) return false;

            float dx = point.X - clickX;
            float dy = point.Y - clickY;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            return distance < 40; 
        }

        private void PicDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            if (isMovingRed)
            {
                redPoint.X = e.X + offsetX;
                redPoint.Y = e.Y + offsetY;
            }
            else if (isMovingOrange)
            {
                orangePoint.X = e.X + offsetX;
                orangePoint.Y = e.Y + offsetY;
            }
            else if (isMovingYellow)
            {
                yellowPoint.X = e.X + offsetX;
                yellowPoint.Y = e.Y + offsetY;
            }
            else if (isMovingGreen)
            {
                greenPoint.X = e.X + offsetX;
                greenPoint.Y = e.Y + offsetY;
            }
            else if (isMovingCyan)
            {
                cyanPoint.X = e.X + offsetX;
                cyanPoint.Y = e.Y + offsetY;
            }
            else if (isMovingBlue)
            {
                bluePoint.X = e.X + offsetX;
                bluePoint.Y = e.Y + offsetY;
            }
            else if (isMovingMagenta)
            {
                magentaPoint.X = e.X + offsetX;
                magentaPoint.Y = e.Y + offsetY;
            }
        }

        private void PicDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            isMovingRed = isMovingOrange = isMovingYellow = isMovingGreen =
            isMovingCyan = isMovingBlue = isMovingMagenta = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }
    }
}
