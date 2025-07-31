using System;
namespace OpenVNC
{
    public struct Vector
    {
        #region Properties
        private double _x;
        private double _y;
        public double x
        {
            get
            {
                return _x;
            }
            set
            {
                if (!MathHelper.IsRealNumber(value))
                {
                    throw new ArgumentException("Value was not a real number.");
                }
                _x = value;
            }
        }
        public double y
        {
            get
            {
                return _y;
            }
            set
            {
                if (!MathHelper.IsRealNumber(value))
                {
                    throw new ArgumentException("Value was not a real number.");
                }
                _y = value;
            }
        }
        #endregion
        #region Constants
        public static Vector Zero
        {
            get
            {
                return new Vector(0, 0);
            }
        }
        public static Vector One
        {
            get
            {
                return new Vector(1, 1);
            }
        }
        public static Vector Up
        {
            get
            {
                return new Vector(0, 1);
            }
        }
        public static Vector Down
        {
            get
            {
                return new Vector(0, -1);
            }
        }
        public static Vector Right
        {
            get
            {
                return new Vector(1, 0);
            }
        }
        public static Vector Left
        {
            get
            {
                return new Vector(-1, 0);
            }
        }
        #endregion
        #region Constructors
        public Vector(double x, double y)
        {
            if (!MathHelper.IsRealNumber(x))
            {
                throw new ArgumentException("X was not a real number.");
            }
            _x = x;
            if (!MathHelper.IsRealNumber(y))
            {
                throw new ArgumentException("Y was not a real number.");
            }
            _y = y;
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.Vector({_x}, {_y})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(Vector))
            {
                return false;
            }
            else
            {
                return this == (Vector)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(Vector a, Vector b)
        {
            return (a._x == b._x) && (a._y == b._y);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a._x + b._x, a._y + b._y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a._x - b._x, a._y - b._y);
        }
        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a._x * b._x, a._y * b._y);
        }
        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a._x / b._x, a._y / b._y);
        }
        public static Vector operator +(Vector a, double b)
        {
            if (!MathHelper.IsRealNumber(b))
            {
                throw new ArgumentException("B was not a real number.");
            }
            return new Vector(a._x + b, a._y + b);
        }
        public static Vector operator -(Vector a, double b)
        {
            if (!MathHelper.IsRealNumber(b))
            {
                throw new ArgumentException("B was not a real number.");
            }
            return new Vector(a._x - b, a._y - b);
        }
        public static Vector operator *(Vector a, double b)
        {
            if (!MathHelper.IsRealNumber(b))
            {
                throw new ArgumentException("B was not a real number.");
            }
            return new Vector(a._x * b, a._y * b);
        }
        public static Vector operator /(Vector a, double b)
        {
            if (!MathHelper.IsRealNumber(b))
            {
                throw new ArgumentException("B was not a real number.");
            }
            return new Vector(a._x / b, a._y / b);
        }
        public static Vector operator +(Vector a)
        {
            return new Vector(MathHelper.Abs(a._x), MathHelper.Abs(a._y));
        }
        public static Vector operator -(Vector a)
        {
            return new Vector(MathHelper.Abs(a._x) * -1, MathHelper.Abs(a._y) * -1);
        }
        #endregion
    }
}