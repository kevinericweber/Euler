using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are
     * 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
     * If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words,
     * how many letters would be used?
     * NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two)
     * contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
     * The use of "and" when writing out numbers is in compliance with British usage.
     */
    class Problem17 : answerBaseClass
    {
        // note: this wasn't written in a way that's easily testable.  Looking back on it,
        // maybe I should've said "heck with efficiency, make it testable" and had it actually
        // generate the strings for each number.
        // As it is, it's pretty hard-coded for specifically 1000 and less via mathematical formula.
        public override string GetAnswer()
        {
            int finalAnswer = GetThreeDigitSum();
            
            return finalAnswer.ToString();
        }

        public int GetThreeDigitSum()
        {
            int tensAndOnesPlaceTotalCharacters = GetTotalCharactersFor1Through99() * 10; // for every 'eightyfive', there's 'onehudredeightyfive', 'twohundredeightyfive', etc

            int numberOfLettersPrecedingTheWordHundred = GetSingleDigitWordSum() * 100;
            int numberOfLettersFromTheWordHundred = "hundred".Length * 900;
            int numberOfLettersFromTheWordAND = "and".Length * (900 - 9);  // numbers cleanly divisible by 100 won't have an 'and'

            return tensAndOnesPlaceTotalCharacters +
                numberOfLettersPrecedingTheWordHundred +
                numberOfLettersFromTheWordHundred +
                numberOfLettersFromTheWordAND;
        }

        public int GetTotalCharactersFor1Through99()
        {
            int onedigits = GetSingleDigitWordSum();
            int tenAndTeens = GetTenAndTeensWordSum();
            int rest = 10 * GetTensPlacesWordsSum() + 8 * GetSingleDigitWordSum();
            return onedigits + tenAndTeens + rest;
        }

        public int GetSingleDigitWordSum()
        {
            string temp = "onetwothreefourfivesixseveneightnine";
            return temp.Length;
        }

        public int GetTenAndTeensWordSum()
        {
            string temp = "teneleventwelvethirteenfourteenfifteensixteenseventeeneighteennineteen";
            return temp.Length;
        }

        public int GetTensPlacesWordsSum()
        {
            string temp = "twentythirtyfourtyfiftysixtyseventyeightyninety";
            return temp.Length;
        }
    }
}
