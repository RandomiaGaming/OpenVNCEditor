namespace OpenVNC
{
    public struct LineSegment
    {
        #region Properties
        public Vector start;
        public Vector end;
        #endregion
        #region Constants
        public static LineSegment Up
        {
            get
            {
                return new LineSegment(0, 0, 0, 1);
            }
        }
        public static LineSegment Down
        {
            get
            {
                return new LineSegment(0, 0, 0, -1);
            }
        }
        public static LineSegment Right
        {
            get
            {
                return new LineSegment(0, 0, 1, 0);
            }
        }
        public static LineSegment Left
        {
            get
            {
                return new LineSegment(0, 0, -1, 0);
            }
        }
        public static LineSegment UpRight
        {
            get
            {
                return new LineSegment(0, 0, 1, 1);
            }
        }
        public static LineSegment UpLeft
        {
            get
            {
                return new LineSegment(0, 0, -1, 1);
            }
        }
        public static LineSegment DownRight
        {
            get
            {
                return new LineSegment(0, 0, 1, -1);
            }
        }
        public static LineSegment DownLeft
        {
            get
            {
                return new LineSegment(0, 0, -1, -1);
            }
        }
        #endregion
        #region Constructors
        public LineSegment(double startX, double startY, double endX, double endY)
        {
            start = new Vector(startX, startY);
            end = new Vector(endX, endY);
        }
        public LineSegment(Vector start, Vector end)
        {
            this.start = start;
            this.end = end;
        }
        #endregion
        #region Methods
        public Rect GetBounds()
        {
            return new Rect(MathHelper.Min(start.x, end.x), MathHelper.Min(start.y, end.y), MathHelper.Max(start.x, end.x), MathHelper.Max(start.y, end.y));
        }
        public double DistanceTo(Vector p)
        {
            return MathHelper.Distance(ClosestPointOnLine(p), p);
        }
        public Vector ClosestPointOnLine(Vector p)
        {
            Vector line = (end - start);
            double len = MathHelper.VectorMagnitude(line);
            line = MathHelper.ClampUnitCircle(line);
            Vector v = p - start;
            double d = MathHelper.DotProduct(v, line);
            d = MathHelper.Clamp(d, 0f, len);
            return start + line * d;
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.LineSegment[({start.x}, {start.y}), ({end.x}, {end.y})]";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(LineSegment))
            {
                return false;
            }
            else
            {
                return this == (LineSegment)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(LineSegment a, LineSegment b)
        {
            return (a.start == b.start && a.end == b.end) || (a.start == b.end && a.end == b.start);
        }
        public static bool operator !=(LineSegment a, LineSegment b)
        {
            return !(a == b);
        }
        #endregion
    }
}