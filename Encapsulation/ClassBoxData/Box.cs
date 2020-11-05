using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const double MinSide = 0;
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
            get => this.length;
            private set
            {
                ValidateSide(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            var surface = (2 * this.Length * this.Width)
                + (2 * this.Length * this.Height)
                + (2 * this.Width * this.Height);
            return surface;
        }
        public double CalculateLateralSurface()
        {
            var lateralSurface = (2 * this.Length * this.Height)
                + (2 * this.Width * this.Height);
            return lateralSurface;
        }

        public double CalculateVolume()
        {
            var volume = this.Height * this.Length * this.Width;
            return volume;
        }
        private static void ValidateSide(double parameter, string property)
        {
            if (parameter <= MinSide)
            {
                throw new ArgumentException($"{property} cannot be zero or negative.");
            }
        }



    }
}
