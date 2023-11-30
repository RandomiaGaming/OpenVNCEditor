using System;
namespace OpenVNC
{
    public struct Range
    {
        #region Properties
        private double _min;
        public double min
        {
            get
            {
                return _min;
            }
            set
            {
                if (!MathHelper.IsRealNumber(value))
                {
                    throw new ArgumentException("Value was not a real number.");
                }
                if (value > _max)
                {
                    throw new ArgumentException("Value was greater than max.");
                }
                _min = value;
            }
        }
        private double _max;
        public double max
        {
            get
            {
                return _max;
            }
            set
            {
                if (!MathHelper.IsRealNumber(value))
                {
                    throw new ArgumentException("Value was not a real number.");
                }
                if (value < _min)
                {
                    throw new ArgumentException("Value was less than min.");
                }
                _max = value;
            }
        }
        #endregion
        #region Constructors
        public Range(double min, double max)
        {
            if (!MathHelper.IsRealNumber(min))
            {
                throw new ArgumentException("Min was not a real number.");
            }
            if (!MathHelper.IsRealNumber(max))
            {
                throw new ArgumentException("Max was not a real number.");
            }
            if (max < min)
            {
                throw new Exception("Min must be less than or equal to max.");
            }
            _min = min;
            _max = max;
        }
        #endregion
        #region Methods
        public bool Incapsulates(double value)
        {
            if (!MathHelper.IsRealNumber(value))
            {
                throw new ArgumentException("Value was not a real number.");
            }
            return value >= min && value <= max;
        }
        public bool Incapsulates(Range range)
        {
            if (range.max <= max && range.min >= min)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Overlaps(Range range)
        {
            if (max < range.min || min > range.max)
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
            return $"OpenVNC.Range({min}, {max})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Range))
            {
                return false;
            }
            else
            {
                return this == (Range)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(Range a, Range b)
        {
            return (a.min == b.min) && (a.max == b.max);
        }
        public static bool operator !=(Range a, Range b)
        {
            return !(a == b);
        }
        #endregion
    }
}