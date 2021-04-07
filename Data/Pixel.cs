using System;
using System.Drawing;

namespace MyPhotoshop
{
    public struct Pixel
    {
        #region Fields
        /// <summary>
        /// Red Color
        /// </summary>
        private double _r;
        /// <summary>
        /// Green Color
        /// </summary>
        private double _g;
        /// <summary>
        /// Blue Color
        /// </summary>
        private double _b;
        #endregion

        #region Props
        public double R
        {
            get => _r;
            set 
            {
                _r = CheckValue(value);
            }
        }
        public double G {
            get => _g;
            set
            {
                _g = CheckValue(value);
            }
        }
        public double B 
        { 
            get => _b;
            set
            {
                _b = CheckValue(value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Сhecking that the value is in the valid range 
        /// </summary>
        /// <param name="value">value for checking</param>
        /// <returns>Checked value</returns>
        /// <exception cref="ArgumentException"></exception>
        private double CheckValue(double value)
        {
            if (value > 1 || value < 0) throw new ArgumentException("Color value must be beetween 0 and 1", nameof(value));
            return value;
        }

        /// <summary>
		/// Trim value if is out of valid range
		/// </summary>
		/// <param name="colorValue">Value of myltiply pixel color value on user parametr</param>
		/// <returns>Valid value</returns>
		private static double TrimColorValue(double colorValue)
        {
            if (colorValue < 0) colorValue = 0;
            else if (colorValue > 1) colorValue = 1;
            return colorValue;
        }

        /// <summary>
        /// Convert color value from double to byte 
        /// </summary>
        /// <param name="value">Double color value</param>
        /// <returns>Byte color value</returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte ColorToChannel(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException($"Wrong channel value {value} (the value must be between 0 and 1");
            return (byte)(value * 255);
        }

        public static implicit operator Color(Pixel pixel)
        {
            return Color.FromArgb(
                ColorToChannel(pixel._r),
                ColorToChannel(pixel._g),
                ColorToChannel(pixel._b)
                );
        }

        public static explicit operator Pixel(Color color)
        {
            return new Pixel() 
            { 
                _r = color.R / 255,
                _g = color.G / 255,
                _b = color.B / 255
            };
        }

        public static Pixel operator *(Pixel pixel, double value)
        {
            pixel.R = TrimColorValue(pixel._r * value);
            pixel.G = TrimColorValue(pixel._g * value);
            pixel.B = TrimColorValue(pixel._b * value);
            return pixel;
        }

        public static Pixel operator *(double value, Pixel pixel)
        {
            return pixel * value;
        }
        #endregion
    }
}
