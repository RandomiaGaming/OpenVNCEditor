using System;
namespace OpenVNC
{
    public static class Rastorizor
    {
        /*public static BitMatrix RastorChar(VectorChar vectorChar, ushort pixelHeight, double thickness)
        {
            if(vectorChar is null)
            {
                throw new NullReferenceException("VectorChar was null.");
            }
            if (pixelHeight == 0)
            {
                throw new ArgumentException("pixelHeight must be greater than 0.");
            }
            if(thickness < 0)
            {
                throw new ArgumentException("Thickness must be greater than or equal to 0.");
            }
            if (vectorChar.shapes.Count == 0 || thickness == 0)
            {
                return new BitMatrix(1, pixelHeight, false);
            }
            Rect charRect = vectorChar.GetRect();
            double scaledThickness = charRect.GetHeight() * thickness;
            Rect viewRect = new Rect(charRect.min.x - scaledThickness, charRect.min.y - scaledThickness, charRect.max.x + scaledThickness, charRect.max.y + scaledThickness);
            ushort pixelWidth = (ushort)(pixelHeight * viewRect.GetAspectRatio());
            Vector scalingFactor = new Vector(viewRect.GetWidth() / pixelWidth, viewRect.GetHeight() / pixelHeight);
            Vector subPixelOffset = scalingFactor / 2;
            BitMatrix output = new BitMatrix(pixelWidth, pixelHeight);
            for (ushort x = 0; x < pixelWidth; x++)
            {
                for (ushort y = 0; y < pixelHeight; y++)
                {
                    Vector scaledPoint = viewRect.min + (scalingFactor * new Vector(x, y)) + subPixelOffset;
                    double distanceToChar = double.MaxValue;
                    for (int i = 0; i < vectorChar.shapes.Count; i++)
                    {
                        distanceToChar = MathHelper.Min(vectorChar.shapes[i].GetDistanceToShape(scaledPoint), distanceToChar);
                    }
                    output.SetValue(x, y, distanceToChar <= scaledThickness);
                }
            }
            return output;
        }*/
    }
}
