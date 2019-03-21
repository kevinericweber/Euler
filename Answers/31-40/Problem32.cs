using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem32 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<int> products = new List<int>();

            for (int i = 2; i < 99; i++)
            {
                for (int j = 10; j < 4999; j++)
                {
                    int product = i * j;
                    if (IsPanglacial(i, j, product))
                        products.Add(product);
                }
            }

            return products.Distinct().Sum().ToString();
        }

        private bool IsPanglacial(int i, int j, int prod)
        {
            string combined = i.ToString() + j.ToString() + prod.ToString();
            if (combined.Length != 9) return false;
            int[] digits = combined.Select(c => c - '0').OrderBy(x => x).ToArray();

            for (int z = 0; z < 9; z++)
            {
                if (digits[z] != z + 1) return false;
            }
            return true;
        }
    }
}
