/*
using System;
namespace OpenVNC
{
    public sealed class TEMPLATE
    {
        #region Properties
        private int _exampleProperty = 0;
        public int exampleProperty
        {
            get
            {
                return _exampleProperty;
            }
            set
            {
                _exampleProperty = value;
            }
        }
        #endregion
        #region Constants
        public static TEMPLATE ExampleConstant
        {
            get
            {
                return new TEMPLATE();
            }
        }
        #endregion
        #region Constructors
        private TEMPLATE()
        {

        }
        #endregion
        #region Methods
        public TEMPLATE Clone()
        {
            return new TEMPLATE();
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.TEMPLATE()";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(TEMPLATE))
            {
                return false;
            }
            else
            {
                return this == (TEMPLATE)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(TEMPLATE a, TEMPLATE b)
        {
            if (a is null && b is null)
            {
                return true;
            }
            else if (a is null || b is null)
            {
                return false;
            }
            else
            {
                return a.exampleProperty == b.exampleProperty;
            }
        }
        public static bool operator !=(TEMPLATE a, TEMPLATE b)
        {
            return !(a == b);
        }
        #endregion
    }
}
*/