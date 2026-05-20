using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static particleSystem.Particle;

namespace particleSystem
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public List<ImpactPoint> impactPoints = new List<ImpactPoint>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 0;
        public int ParticlesCount;

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public int CountParticlesTickCreate = 40; // такое значение потому timer интервала 40мс, следовательно 1000мс(1 секунда) / 40 = 25 тиков в секунду(довольно плавно)

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            return particle;
        }

        public void UpdateState()
        {
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                var particle = particles[i];
                particle.Life -= 1;

                if (particle.Life < 0)
                {
                    particles.RemoveAt(i);
                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            foreach (var point in impactPoints)
            {
                if (point is RadarPoint radar)
                {
                    radar.RemoveDeadParticles();
                }
            }

            for (var i = 0; i < CountParticlesTickCreate; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints) 
            {
                point.Render(g); 
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.rand.Next(100);
            particle.X = X;     
            particle.Y = Y;

            var direction = (double)Particle.rand.Next(360);
            var speed = 1 + Particle.rand.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rand.Next(10);
        }

        public List<Particle> GetParticles()
        {
            return particles;
        }
    }
}
