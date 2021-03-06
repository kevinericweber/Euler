﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
     * 
     *     3
     *    7 4
     *   2 4 6
     *  8 5 9 3
     * 
     * That is, 3 + 7 + 4 + 9 = 23.
     * Find the maximum total from top to bottom of the triangle below:
     * 
     * [Triangle omitted for space; see GetStartingTriangle for actual values]
     * 
     * NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.
     * However, Problem 67, is the same challenge with a triangle containing one-hundred rows;
     * it cannot be solved by brute force, and requires a clever method! ;o)
     */
    public class Problem18 : testableAnswer
    {
        public override string GetAnswer()
        {
            int[,] maxPathTriangle = GetStartingTriangle();
            return GetAnswerForTriangle(maxPathTriangle).ToString();
        }


        private int GetAnswerForTriangle(int[,] maxPathTriangle)
        {
            // Note: This function mutates the input array.
            int height = (int)maxPathTriangle.GetLongLength(0);

            for (int rowToModify = height - 2; rowToModify >= 0; rowToModify--)
            {
                for (int arraySlot = 0; arraySlot <= rowToModify; arraySlot++)
                {
                    int maxAmountFromHereDownwards = maxPathTriangle[rowToModify + 1, arraySlot];
                    if (arraySlot < height - 1)
                        if (maxPathTriangle[rowToModify + 1, arraySlot + 1] > maxAmountFromHereDownwards)
                            maxAmountFromHereDownwards = maxPathTriangle[rowToModify + 1, arraySlot + 1];
                    maxPathTriangle[rowToModify, arraySlot] += maxAmountFromHereDownwards;
                }
            }

            return maxPathTriangle[0, 0];

        }

        private int[,] GetStartingTriangle()
        {

            int[,] retVal = new int[15, 15]
                {
                        {75,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {95,64,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {17,47,82,0,0,0,0,0,0,0,0,0,0,0,0},
                        {18,35,87,10,0,0,0,0,0,0,0,0,0,0,0},
                        {20,4,82,47,65,0,0,0,0,0,0,0,0,0,0},
                        {19,1,23,75,3,34,0,0,0,0,0,0,0,0,0},
                        {88,2,77,73,7,63,67,0,0,0,0,0,0,0,0},
                        {99,65,4,28,6,16,70,92,0,0,0,0,0,0,0},
                        {41,41,26,56,83,40,80,70,33,0,0,0,0,0,0},
                        {41,48,72,33,47,32,37,16,94,29,0,0,0,0,0},
                        {53,71,44,65,25,43,91,52,97,51,14,0,0,0,0},
                        {70,11,33,28,77,73,17,78,39,68,17,57,0,0,0},
                        {91,71,52,38,17,14,91,43,58,50,27,29,48,0,0},
                        {63,66,4,68,89,53,67,30,73,16,69,87,40,31,0},
                        {4,62,98,27,23,9,70,98,73,93,38,53,60,4,23}
                };
            return retVal;
        }

        public override bool KnownTestPasses()
        {
            int expected = 23;
            int[,] testTriangle = GetTestTriangle();
            int actual = GetAnswerForTriangle(testTriangle);
            return (expected == actual);
        }

        private int[,] GetTestTriangle()
        {
            int[,] retVal = new int[4, 4]
            {
                {3,0,0,0 },
                {7,4,0,0 },
                {2,4,6,0 },
                {8,5,9,3 }
            };
            return retVal;
        }
    }
    
}
