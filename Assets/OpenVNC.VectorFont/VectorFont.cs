/*using System;
namespace OpenVNC.VectorFont
{
    public sealed class VectorFont
    {
        #region Properties
public List<VectorChar> buffer = 
        #endregion
        #region Constants
        public static VectorFont ExampleConstant
        {
            get
            {
                return new VectorFont();
            }
        }
        #endregion
        #region Constructors
        private VectorFont()
        {

        }
        #endregion
        #region Methods
        public VectorFont Clone()
        {
            return new VectorFont();
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.TEMPLATE()";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(VectorFont))
            {
                return false;
            }
            else
            {
                return this == (VectorFont)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(VectorFont a, VectorFont b)
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
        public static bool operator !=(VectorFont a, VectorFont b)
        {
            return !(a == b);
        }
        #endregion
    }
}
*/