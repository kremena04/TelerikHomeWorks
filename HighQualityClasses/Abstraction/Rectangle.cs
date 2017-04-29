using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Width can not be negative");
                }

                width = value;
            }
        }

        private double height;
        public virtual double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height can not be negative");
                }

                height = value;
            }
        }
        public Rectangle()
            : base()
        {
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
