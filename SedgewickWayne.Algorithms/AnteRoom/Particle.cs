using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class Particle
    {
        private const double INFINITY = double.PositiveInfinity;
        private double rx;
        private double ry;
        private double vx;
        private double vy;
        private double radius;
        private double mass;
        private Color color;
        private int count;


        public virtual double timeToHit(Particle p)
        {
            if (this == p)
            {
                return double.PositiveInfinity;
            }
            double num = p.rx - this.rx;
            double num2 = p.ry - this.ry;
            double num3 = p.vx - this.vx;
            double num4 = p.vy - this.vy;
            double num5 = num * num3 + num2 * num4;
            if (num5 > (double)0f)
            {
                return double.PositiveInfinity;
            }
            double num6 = num3 * num3 + num4 * num4;
            double num7 = num * num + num2 * num2;
            double num8 = this.radius + p.radius;
            double num9 = num5 * num5 - num6 * (num7 - num8 * num8);
            if (num9 < (double)0f)
            {
                return double.PositiveInfinity;
            }
            return -(num5 + java.lang.Math.sqrt(num9)) / num6;
        }
        public virtual double timeToHitVerticalWall()
        {
            if (this.vx > (double)0f)
            {
                return ((double)1f - this.rx - this.radius) / this.vx;
            }
            if (this.vx < (double)0f)
            {
                return (this.radius - this.rx) / this.vx;
            }
            return double.PositiveInfinity;
        }
        public virtual double timeToHitHorizontalWall()
        {
            if (this.vy > (double)0f)
            {
                return ((double)1f - this.ry - this.radius) / this.vy;
            }
            if (this.vy < (double)0f)
            {
                return (this.radius - this.ry) / this.vy;
            }
            return double.PositiveInfinity;
        }


        public virtual void draw()
        {
            StdDraw.setPenColor(this.color);
            StdDraw.filledCircle(this.rx, this.ry, this.radius);
        }

        public virtual void move(double d)
        {
            this.rx += this.vx * d;
            this.ry += this.vy * d;
        }

        public virtual void bounceOff(Particle p)
        {
            double num = p.rx - this.rx;
            double num2 = p.ry - this.ry;
            double num3 = p.vx - this.vx;
            double num4 = p.vy - this.vy;
            double num5 = num * num3 + num2 * num4;
            double num6 = this.radius + p.radius;
            double num7 = 2.0 * this.mass * p.mass * num5 / ((this.mass + p.mass) * num6);
            double num8 = num7 * num / num6;
            double num9 = num7 * num2 / num6;
            this.vx += num8 / this.mass;
            this.vy += num9 / this.mass;
            p.vx -= num8 / p.mass;
            p.vy -= num9 / p.mass;
            this.count++;
            p.count++;
        }

        public virtual void bounceOffVerticalWall()
        {
            this.vx = -this.vx;
            this.count++;
        }

        public virtual void bounceOffHorizontalWall()
        {
            this.vy = -this.vy;
            this.count++;
        }


        public Particle()
        {
            this.rx = java.lang.Math.random();
            this.ry = java.lang.Math.random();
            this.vx = 0.01 * (java.lang.Math.random() - 0.5);
            this.vy = 0.01 * (java.lang.Math.random() - 0.5);
            this.radius = 0.01;
            this.mass = 0.5;
            this.color = Color.BLACK;
        }


        public Particle(double d1, double d2, double d3, double d4, double d5, double d6, Color c)
        {
            this.vx = d3;
            this.vy = d4;
            this.rx = d1;
            this.ry = d2;
            this.radius = d5;
            this.mass = d6;
            this.color = c;
        }
        public virtual int count()
        {
            return this.count;
        }
        public virtual double kineticEnergy()
        {
            return 0.5 * this.mass * (this.vx * this.vx + this.vy * this.vy);
        }
    }
}
