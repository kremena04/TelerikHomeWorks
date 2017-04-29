using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSize
{
    public class Size
    {
        private double width;
        private double height;
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public static Size GetRotatedSize(Size s, 
            double angleOfTheFigureThatWillBeRotaed)
        {
            double width = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Width +
                 Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Height;
            double height = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Width +
                    Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Height;

            Size rotatedSize = new Size(width, height);

            return rotatedSize;
        }
    }
}
