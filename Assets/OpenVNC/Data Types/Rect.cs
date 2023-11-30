using System;
namespace OpenVNC
{
    public struct Rect
    {
        #region Properties
        private Vector _min;
        public Vector min
        {
            get
            {
                return _min;
            }
            set
            {
                if (value.x > _max.x)
                {
                    throw new ArgumentException("Min.x must be less than or equal to max.x.");
                }
                if (value.y > _max.y)
                {
                    throw new ArgumentException("Min.y must be less than or equal to max.y.");
                }
                _min = value;
            }
        }
        private Vector _max;
        public Vector max
        {
            get
            {
                return _max;
            }
            set
            {
                if (value.x > _min.x)
                {
                    throw new ArgumentException("Max.x must be greater than or equal to min.x.");
                }
                if (value.y > _min.y)
                {
                    throw new ArgumentException("Max.y must be greater than or equal to min.y.");
                }
                _max = value;
            }
        }
        #endregion
        #region Constants
        public static Rect UnitSquare
        {
            get
            {
                return new Rect(-0.5, -0.5, 0.5, 0.5);
            }
        }
        #endregion
        #region Constructors
        public Rect(Vector min, Vector max)
        {
            _max = max;
            if (min.x > max.x)
            {
                throw new ArgumentException("Min.x must be less than or equal to max.x.");
            }
            if (min.y > max.y)
            {
                throw new ArgumentException("Min.y must be less than or equal to max.y.");
            }
            _min = min;
        }
        public Rect(double minX, double minY, double maxX, double maxY)
        {
            if(!MathHelper.IsRealNumber(minX))
            {
                throw new ArgumentException("MinX was not a real number.");
            }
            if (!MathHelper.IsRealNumber(minY))
            {
                throw new ArgumentException("MinY was not a real number.");
            }
            if (!MathHelper.IsRealNumber(maxX))
            {
                throw new ArgumentException("MaxX was not a real number.");
            }
            if (!MathHelper.IsRealNumber(maxY))
            {
                throw new ArgumentException("MaxY was not a real number.");
            }
            if (minX > maxX)
            {
                throw new ArgumentException("MinX must be less than or equal to maxX.");
            }
            if (minY > maxY)
            {
                throw new ArgumentException("MinY must be less than or equal to maxY.");
            }
            _min = new Vector(minX, minY);
            _max = new Vector(maxX, maxY);
        }
        #endregion
        #region Methods
        public bool Incapsulates(Vector value)
        {
            return value.x >= _min.x && value.x <= _max.x && value.y >= _min.y && value.y <= _max.y;
        }
        public bool Incapsulates(Rect rect)
        {
            if (_max.x >= rect._max.x && _min.x <= rect._min.x && _max.y >= rect._max.y && _min.y <= rect._min.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Overlaps(Rect rect)
        {
            if (_max.x < rect._min.x || _min.x > rect._max.x || _max.y < rect._min.y || _min.y > rect._max.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.Rect[{_min}, {_max}]";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Rect))
            {
                return false;
            }
            else
            {
                return this == (Rect)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(Rect a, Rect b)
        {
                return (a._min == b._min) && (a._max == b._max);
        }
        public static bool operator !=(Rect a, Rect b)
        {
            return !(a == b);
        }
        #endregion
    }
}