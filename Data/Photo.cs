using System;
using System.Drawing;

namespace MyPhotoshop
{
	public class Photo
	{
		#region Fields
		
		/// <summary>
		/// Width photo
		/// </summary>
		private readonly int _width;
		
		/// <summary>
		/// Height photo
		/// </summary>
		private readonly int _height;
		
		/// <summary>
		/// Matrix pixels
		/// </summary>
		private readonly Pixel[,] _matrix;

		/// <summary>
		/// Create new Photo
		/// </summary>
		/// <param name="width">Photo width</param>
		/// <param name="height">Photo height</param>

		#endregion
		public Photo(int width, int height)
		{
			if (height <= 0) throw new ArgumentException("Value of height cannot be a less than or equals 0", nameof(height));
			if (width <= 0) throw new ArgumentException("Value of width cannot be a less than or equals 0", nameof(width));

			_width = width;
			_height = height;
			_matrix = new Pixel[width, height];
		}

		#region Props
		public int Width => _width;

		public int Height => _height;
        #endregion

        #region Methods
		public Pixel this[int x, int y]
        {
            get
            {
				return _matrix[x, y];
            }
			set
            {
				_matrix[x, y] = value;
            }
        }

		public static implicit operator Bitmap(Photo photo)
        {
			var bmp = new Bitmap(photo.Width, photo.Height);
			for (int x = 0; x < bmp.Width; x++)
				for (int y = 0; y < bmp.Height; y++)
					bmp.SetPixel(
						x, 
						y, 
						photo[x,y]
						);

			return bmp;
		}

		public static explicit operator Photo(Bitmap bitmap)
        {
			var photo = new Photo(bitmap.Width, bitmap.Height);

			for (int x = 0; x < bitmap.Width; x++)
				for (int y = 0; y < bitmap.Height; y++)
				{
					photo[x, y] = (Pixel)bitmap.GetPixel(x, y);
				}

			return photo;
		}
        #endregion
    }
}

