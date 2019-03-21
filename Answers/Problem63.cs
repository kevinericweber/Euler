using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.Diagnostics;

namespace Euler
{
    class Problem63 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int answerCount = 0;

            for (int exponentBase = 1; exponentBase <= 9; exponentBase++)
            {
                double curVal = exponentBase;

                while (curVal >= 1)
                {
                    answerCount++;
                    curVal = curVal * exponentBase / 10.0;
                }
            }

            return answerCount.ToString();
        }
    }
    
    
}
