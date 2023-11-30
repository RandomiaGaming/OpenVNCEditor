using System;
using System.Collections.Generic;
namespace OpenVNC.VectorFont
{
    public sealed class VectorChar
    {
        #region Properties
        public CharCode charCode = CharCode.Upper_Case_A;
        private List<LineSegment> buffer = new List<LineSegment>();
        public int bufferSize
        {
            get
            {
                return GetBufferSize();
            }
        }
        #endregion
        #region Constructors
        private VectorChar()
        {
            charCode = CharCode.Upper_Case_A;
            buffer = new List<LineSegment>();
        }
        public VectorChar(CharCode charCode)
        {
            this.charCode = charCode;
            buffer = new List<LineSegment>();
        }
        #endregion
        #region Methods
        public VectorChar Clone()
        {
            VectorChar output = new VectorChar(charCode);
            if (buffer is null)
            {
                buffer = new List<LineSegment>();
            }
            output.buffer = new List<LineSegment>(buffer);
            return output;
        }
        public Rect GetBounds()
        {
            if (buffer is null)
            {
                buffer = new List<LineSegment>();
            }
            if (buffer.Count == 0)
            {
                return new Rect(0, 0, 0, 0);
            }
            Rect output = buffer[0].GetBounds();
            for (int i = 1; i < buffer.Count; i++)
            {
                Rect lsBounds = buffer[i].GetBounds();
                output = new Rect(MathHelper.Min(output.min.x, lsBounds.min.x), MathHelper.Min(output.min.y, lsBounds.min.y), MathHelper.Max(output.max.x, lsBounds.max.x), MathHelper.Min(output.max.y, lsBounds.max.y));
            }
            return output;
        }
        public int GetBufferSize()
        {
            return buffer.Count;
        }
        public void SetBufferSample(int index, LineSegment value)
        {
            if (index < 0 || index >= buffer.Count)
            {
                throw new ArgumentOutOfRangeException("Index was out of bounds.");
            }
            buffer[index] = value;
        }
        public LineSegment GetBufferSample(int index)
        {
            if (index < 0 || index >= buffer.Count)
            {
                throw new ArgumentOutOfRangeException("Index was out of bounds.");
            }
            return buffer[index];
        }
        public void RemoveBufferSample(int index)
        {
            if (index < 0 || index >= buffer.Count)
            {
                throw new ArgumentOutOfRangeException("Index was out of bounds.");
            }
            buffer.RemoveAt(index);
        }
        public void AddBufferSample(LineSegment value)
        {
            buffer.Add(value);
        }
        public void SetBuffer(List<LineSegment> buffer)
        {
            if (buffer is null)
            {
                throw new NullReferenceException("Buffer was null.");
            }
            buffer.Capacity = int.MaxValue;
            this.buffer = buffer;
        }
        public List<LineSegment> GetBuffer()
        {
            return new List<LineSegment>(buffer);
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"OpenVNC.VectorFont.VectorChar({charCode})";
        }
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != typeof(VectorChar))
            {
                return false;
            }
            else
            {
                return this == (VectorChar)obj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(VectorChar a, VectorChar b)
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
                if (a.charCode != b.charCode || a.buffer.Count != b.buffer.Count)
                {
                    return false;
                }
                for (int i = 0; i < a.buffer.Count; i++)
                {
                    if (a.buffer[i] != b.buffer[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool operator !=(VectorChar a, VectorChar b)
        {
            return !(a == b);
        }
        public LineSegment this[int index]
        {
            get
            {
                return GetBufferSample(index);
            }
            set
            {
                SetBufferSample(index, value);
            }
        }
        #endregion
    }
}