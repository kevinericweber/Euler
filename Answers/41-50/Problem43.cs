using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem43 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<string> possibilities = new List<string>();

            Func<string, char, string> AppendNewChar = (s, c) => s + c;
            Func<string, char, string> PrefixNewChar = (s, c) => c + s;

            possibilities.Add("");

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 2);

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 3);

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 5);

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 7);

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 11);

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 13);

            possibilities = ApplyEachPossibleDigit(possibilities, AppendNewChar);
            possibilities = RemoveEntriesWhereLastThreeDontDivideBy(possibilities, 17);

            possibilities = ApplyEachPossibleDigit(possibilities, PrefixNewChar);

            StringNum answer = possibilities.Select(s => new StringNum(s)).Aggregate((x, y) => StringNum.Add(x, y));


            return answer.ToString();
        }

        private List<string> ApplyEachPossibleDigit(List<string> startList, Func<string, char, string> whatToDoWithNewChar)
        {
            List<string> retVal = new List<string>();
            foreach (string origItem in startList)
            {
                for (char newChar = '0'; newChar <= '9'; newChar++)
                {
                    if (!origItem.Contains(newChar))
                        retVal.Add(whatToDoWithNewChar(origItem, newChar));
                }
            }
            return retVal;
        }

        private List<string> RemoveEntriesWhereLastThreeDontDivideBy(List<string> possibilities, int divisor)
        {
            List<string> retVal = new List<string>();
            foreach (string possibility in possibilities)
            {
                string lastThree = possibility.Substring(possibility.Length - 3);
                int numVersion = int.Parse(lastThree);
                if (numVersion % divisor == 0)
                    retVal.Add(possibility);
            }
            return retVal;
        }

    }
}
