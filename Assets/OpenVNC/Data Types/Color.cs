namespace OpenVNC
{
    public struct Color
    {
        #region Properties
        public byte r;
        public byte g;
        public byte b;
        #endregion
        #region Constants
        public static Color Black
        {
            get
            {
                return new Color(0, 0, 0);
            }
        }
        public static Color White
        {
            get
            {
                return new Color(255, 255, 255);
            }
        }
        public static Color Red
        {
            get
            {
                return new Color(255, 0, 0);
            }
        }
        public static Color Yellow
        {
            get
            {
                return new Color(255, 255, 0);
            }
        }
        public static Color Green
        {
            get
            {
                return new Color(0, 255, 0);
            }
        }
        public static Color LightBlue
        {
            get
            {
                return new Color(0, 255, 255);
            }
        }
        public static Color Blue
        {
            get
            {
                return new Color(0, 0, 255);
            }
        }
        public static Color Pink
        {
            get
            {
                return new Color(255, 0, 255);
            }
        }
        #endregion
        #region Constructors
        public Color(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.Color({r}, {g}, {b})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Color))
            {
                return false;
            }
            else
            {
                return this == (Color)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(Color a, Color b)
        {
                return (a.r == b.r && a.g == b.g && a.b == b.b);
        }
        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }
        #endregion
    }
}