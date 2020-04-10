using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            return !(r1.Top > r2.Bottom || r2.Top > r1.Bottom || r1.Right < r2.Left || r2.Right < r1.Left);
               
            
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (AreIntersected(r1, r2))
            {
                var x1 = Math.Max(r1.Left, r2.Left);
                var x2 = Math.Min(r1.Right, r2.Right);
                var y1 = Math.Max(r1.Top, r2.Top);
                var y2 = Math.Min(r1.Bottom, r2.Bottom);
                return Math.Abs(x2-x1) * Math.Abs(y2-y1);
            }
            else
                return 0;
		}
		
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
                return 0;
            else if (r2.Left >= r1.Left && r2.Right <= r1.Right && r2.Top >= r1.Top && r2.Bottom <= r1.Bottom)
                return 1;
			else
                return -1;
		}
	}
}