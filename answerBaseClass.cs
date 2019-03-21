using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{

    public abstract class answerBaseClass
    {
        public abstract string GetAnswer();

        public override string ToString()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();
            string answer = this.GetAnswer();
            sw.Stop();
            int msTaken = (int)sw.ElapsedMilliseconds;
            return this.Name + " : " + msTaken + " ms  " + answer;
        }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }

    public abstract class testableAnswer : answerBaseClass
    {
        public abstract bool KnownTestPasses();

        public override string ToString()
        {
            string response = base.ToString();
            response += Environment.NewLine;
            response += "    Test Passes: " + (KnownTestPasses() ? "true" : "FALSE");
            return response;
        }
    }
}
