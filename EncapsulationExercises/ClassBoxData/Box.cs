using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Length cannot be zero or negative.");
                    }
                    length = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Width cannot be zero or negative.");
                    }
                    width = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Height cannot be zero or negative.");
                    }
                    height = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        public double SurfaceArea()
        {
            return 2 * (Height * Width) + 2 * (Width * Length) + 2 * (Length * Height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * Height * (Length + Width);
        }

        public double Volume()
        {
            return Width * Height * Length;
        }
    }
}
