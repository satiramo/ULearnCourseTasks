using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        public static double calcVectorLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt( (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) );  //2E
        }

        public static double calcCos(double firstAdjacentSide, double secondAdjacentSide, double oppositeSide)  //max E
        {
            return (firstAdjacentSide * firstAdjacentSide + secondAdjacentSide * secondAdjacentSide - 
                    oppositeSide * oppositeSide) / (2 * firstAdjacentSide * secondAdjacentSide);
        }

        public static double scalarMultiplication(double firstVectorLen, double secondVectorLen, double angleCos)   //
        {
            return firstVectorLen * secondVectorLen * angleCos;
        }

        public static bool isInRange(double value, double rangeStart, double rangeEnd)
        {
            const double EPS = 1e-3;
            return (Math.Abs(value - rangeStart) >= EPS && Math.Abs(value - rangeEnd) <= EPS) 
                    || (Math.Abs(value - rangeEnd) >= EPS && Math.Abs(value - rangeStart) <= EPS);
        }		
        
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            const double EPS = 1e-3;
            var lengthAB = calcVectorLength(ax, ay, bx, by);
            var lengthBC = calcVectorLength(bx, by, x, y);
            var lengthAC = calcVectorLength(ax, ay, x, y);
            var cosCAB = calcCos(lengthAC, lengthAB, lengthBC);
            var cosCBA = calcCos(lengthBC, lengthAB, lengthAC);            
            var angleCAB = Math.Acos(cosCAB);
            var angleCBA = Math.Acos(cosCBA);

            if (Math.Abs(lengthAC)<= EPS || Math.Abs(lengthBC)<= EPS || (angleCAB == 0 && isInRange(x, ax, bx)))
                return 0;
            else
                return 6;
            
           
		}
	}
}