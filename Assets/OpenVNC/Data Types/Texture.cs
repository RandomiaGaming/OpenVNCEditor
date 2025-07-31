using System;
namespace OpenVNC
{
    public struct Texture
    {
        #region Properties
        private ushort _width;
        public ushort width
        {
            get
            {
                return width;
            }
        }
        private ushort _height;
        public ushort height
        {
            get
            {
                return height;
            }
        }
        private Color[] buffer;
        #endregion
        #region Constants
        public static Texture Empty
        {
            get
            {
                return new Texture(0, 0, null);
            }
        }
        #endregion
        #region Constructors
        public Texture(ushort width, ushort height)
        {
            if (width == 0)
            {
                throw new ArgumentException("Width was less than or equal to 0.");
            }
            _width = width;
            if (height == 0)
            {
                throw new ArgumentException("Height was less than or equal to 0.");
            }
            _height = height;
            buffer = new Color[width * height];
        }
        public Texture(ushort width, ushort height, Color[] buffer)
        {
            if (width == 0)
            {
                throw new ArgumentException("Width was less than or equal to 0.");
            }
            _width = width;
            if (height == 0)
            {
                throw new ArgumentException("Height was less than or equal to 0.");
            }
            _height = height;
            if (buffer is null)
            {
                throw new NullReferenceException("Buffer was null.");
            }
            if (buffer.Length != width * height)
            {
                throw new ArgumentException("Buffer was the wrong length.");
            }
            this.buffer = new Color[buffer.Length];
            Array.Copy(buffer, 0, this.buffer, 0, buffer.Length);
        }
        public Texture(int width, int height)
        {
            if (width <= 0 || width > 65535)
            {
                throw new ArgumentException("Width was less than or equal to 0.");
            }
            _width = (ushort)width;
            if (height <= 0 || height > 65535)
            {
                throw new ArgumentException("Height was less than or equal to 0.");
            }
            _height = (ushort)height;
            buffer = new Color[width * height];
        }
        public Texture(int width, int height, Color[] buffer)
        {
            if (width <= 0 || width > 65535)
            {
                throw new ArgumentException("Width was less than or equal to 0.");
            }
            _width = (ushort)width;
            if (height <= 0 || height > 65535)
            {
                throw new ArgumentException("Height was less than or equal to 0.");
            }
            _height = (ushort)height;
            if (buffer is null)
            {
                throw new NullReferenceException("Buffer was null.");
            }
            if (buffer.Length != width * height)
            {
                throw new ArgumentException("Buffer was the wrong length.");
            }
            this.buffer = new Color[buffer.Length];
            Array.Copy(buffer, 0, this.buffer, 0, buffer.Length);
        }
        #endregion
        #region Methods
        public void SetPixel(ushort x, ushort y, Color value)
        {
            if (x >= width || y >= height)
            {
                throw new ArgumentException("Pixel out of bounds.");
            }
            buffer[(y * width) + x] = value;
        }
        public Color GetPixel(ushort x, ushort y)
        {
            if (x >= width || y >= height)
            {
                throw new ArgumentException("Pixel out of bounds.");
            }
            return buffer[(y * width) + x];
        }
        public void SetPixel(int x, int y, Color value)
        {
            if (x < 0 || y < 0 || x > 65534 || y > 65534)
            {
                throw new ArgumentException("Pixel out of bounds.");
            }
            SetPixel((ushort)x, (ushort)y, value);
        }
        public Color GetPixel(int x, int y)
        {
            if (x < 0 || y < 0 || x > 65534 || y > 65534)
            {
                throw new ArgumentException("Pixel out of bounds.");
            }
            return GetPixel((ushort)x, (ushort)y);
        }
        public void SetPixel(Point point, Color value)
        {
            SetPixel(point.x, point.y, value);
        }
        public Color GetPixel(Point point)
        {
            return GetPixel(point.x, point.y);
        }
        public void SetBuffer(Color[] buffer)
        {
            if (buffer is null)
            {
                throw new NullReferenceException("Buffer was null.");
            }
            if (buffer.Length != width * height)
            {
                throw new ArgumentException("Buffer was the wrong length.");
            }
            this.buffer = new Color[buffer.Length];
            Array.Copy(buffer, 0, this.buffer, 0, buffer.Length);
        }
        public Color[] GetBuffer()
        {
            Color[] output = new Color[buffer.Length];
            Array.Copy(buffer, 0, output, 0, buffer.Length);
            return output;
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.Texture({_width}, {_height})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Texture))
            {
                return false;
            }
            else
            {
                return this == (Texture)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(Texture a, Texture b)
        {
            if (a._width != b._width || a._height != b._height || a.buffer.Length != b.buffer.Length)
            {
                return false;
            }
            for (int i = 0; i < a.buffer.Length; i++)
            {
                if (a.buffer[i] != b.buffer[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator !=(Texture a, Texture b)
        {
            return !(a == b);
        }
        #endregion
    }
}