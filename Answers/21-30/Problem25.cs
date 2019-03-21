using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem25 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // yet another BigInteger=Cheating problem.
            // (then again, at this point, I'm reusing the same library I wrote
            // so I'm not sure there's even a point to it...)
            StringNum a = new StringNum("1");
            StringNum b = new StringNum("1");
            StringNum c = new StringNum("2");
            int cIndex = 3;

            while (c.ToString().Length < 1000)
            {
                a = b;
                b = c;
                c = StringNum.Add(a, b);
                cIndex++;
            }
            return cIndex.ToString();
        }
    }
}
