namespace OpenVNC
{
    public struct Point
    {
        #region Properties
        public int x;
        public int y;
        #endregion
        #region Constants
        public static Point Zero
        {
            get
            {
                return new Point(0, 0);
            }
        }
        public static Point One
        {
            get
            {
                return new Point(1, 1);
            }
        }
        public static Point Up
        {
            get
            {
                return new Point(0, 1);
            }
        }
        public static Point Down
        {
            get
            {
                return new Point(0, -1);
            }
        }
        public static Point Right
        {
            get
            {
                return new Point(1, 0);
            }
        }
        public static Point Left
        {
            get
            {
                return new Point(-1, 0);
            }
        }
        #endregion
        #region Constructors
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.Point({x}, {y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Point))
            {
                return false;
            }
            else
            {
                return this == (Point)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(Point a, Point b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }
        public static Point operator *(Point a, Point b)
        {
            return new Point(a.x * b.x, a.y * b.y);
        }
        public static Point operator /(Point a, Point b)
        {
            return new Point(a.x / b.x, a.y / b.y);
        }
        public static Point operator +(Point a, int b)
        {
            return new Point(a.x + b, a.y + b);
        }
        public static Point operator -(Point a, int b)
        {
            return new Point(a.x - b, a.y - b);
        }
        public static Point operator *(Point a, int b)
        {
            return new Point(a.x * b, a.y * b);
        }
        public static Point operator /(Point a, int b)
        {
            return new Point(a.x / b, a.y / b);
        }
        public static Point operator +(Point a)
        {
            return a;
        }
        public static Point operator -(Point a)
        {
            return new Point(a.x * -1, a.y * -1);
        }
        #endregion
    }
}