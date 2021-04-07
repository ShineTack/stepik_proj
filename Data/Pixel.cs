using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (value > 1 || value < 0) throw new ArgumentException("Color value must be beetween 0 and 1", nameof(value));
                _r = value;
            }
        }
        public double G {
            get => _g;
            set
            {
                if (value > 1 || value < 0) throw new ArgumentException("Color value must be beetween 0 and 1", nameof(value));
                _g = value;
            }
        }
        public double B 
        { 
            get => _b;
            set
            {
                if (value > 1 || value < 0) throw new ArgumentException("Color value must be beetween 0 and 1", nameof(value));
                _b = value;
             }
        }
        #endregion
    }
}
