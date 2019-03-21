using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem28 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int targetMatrixSize = 1001;
            if (targetMatrixSize % 2 == 0) throw new Exception("Can't have an even-sized matrix for this problem.");

            int maxRingNum = (targetMatrixSize - 1) / 2;

            int total = 0;
            for (int i = 0; i <= maxRingNum; i++)
            {
                total += GetRingSubtotal(i);
            }
            return total.ToString();
        }


        private int GetRingSubtotal(int ringNum)
        {
            // ring 0 is a 1x1, ring 1 is a 3x3, ring 2 is a 5x5, etc
            if (ringNum <= 0) return 1;
            int sideLen = (ringNum * 2 + 1);
            int maxValueInTopRightSpot = sideLen * sideLen;
            int offsetBetweenMaxAndAvg = 3 * ringNum;
            int avgOfFourCorners = maxValueInTopRightSpot - offsetBetweenMaxAndAvg;
            return avgOfFourCorners * 4;
        }
    }
}
