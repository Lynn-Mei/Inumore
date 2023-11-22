using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Animations
{
    /// <summary>
    /// Class that calculates the operations made on coordinates
    /// </summary>
    public class CoordinateCalculator
    {
        /// <summary>
        /// Calculates a coordinate based on its factored result
        /// </summary>
        /// <param name="currentPos">current coordinate</param>
        /// <param name="movementPos">movement's coordinates</param>
        /// <param name="resultPos">factored result</param>
        /// <returns>resulting coordinate</returns>
        public float calculateCoordinate(float currentPos, float movementPos, float resultPos)
        {
            resultPos = this.roundCoordinate(resultPos);
            int newVal = (int)currentPos + (int)resultPos;
            int start = (int)Math.Min(currentPos, movementPos);
            int stop = (int)Math.Max(currentPos, movementPos);

            if (!Enumerable.Range(start, stop).Contains(newVal))
            {
                resultPos = movementPos - currentPos;
            }
            return resultPos;
        }

        /// <summary>
        /// Rounds the coordinate up if above 0
        /// </summary>
        /// <param name="coordinate">coordinate</param>
        /// <returns>rounded coordinate</returns>
        private float roundCoordinate(float coordinate)
        {
            float res = (float)Math.Floor((double)coordinate);
            if (coordinate > 0)
            {
                res = (float)Math.Round(coordinate);
            }
            return res;
        }
    }
}
