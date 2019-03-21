using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem59 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // NOTE: With the info given, brute-force is particularly stupid.  We're pretty sure that the most common character is a space
            // and we know the password length (3), so all we need to do is get the most common cipher char for each password slot.
            // Assuming that the cipher of that character de-cyphers to a space, we just need to XOR the most common value with 32.
            // Sure enough, the example file was decryptable this way.

            int answer = 0;

            string fileContents = System.IO.File.ReadAllText(@"p059_cipher.txt");

            string[] bits = fileContents.Split(',');
            int[] sequence = bits.Select(s => int.Parse(s)).ToArray();

            List<int>[] sectionedOff = new List<int>[3];
            sectionedOff[0] = new List<int>();
            sectionedOff[1] = new List<int>();
            sectionedOff[2] = new List<int>();

            int slot = 0;
            for(int i = 0; i < sequence.Count(); i++)
            {
                sectionedOff[slot].Add(sequence[i]);
                slot++;
                if (slot == 3) slot = 0;
            }

            int[] spaces = new int[3];
            spaces[0] = sectionedOff[0].GroupBy(n => n).OrderByDescending(g => g.Count()).Select(x => x.Key).First();
            spaces[1] = sectionedOff[1].GroupBy(n => n).OrderByDescending(g => g.Count()).Select(x => x.Key).First();
            spaces[2] = sectionedOff[2].GroupBy(n => n).OrderByDescending(g => g.Count()).Select(x => x.Key).First();

            int[] keys = new int[3];
            keys[0] = spaces[0] ^ 32;
            keys[1] = spaces[1] ^ 32;
            keys[2] = spaces[2] ^ 32;

            string decrypted = "";
            slot = 0;
            for (int i = 0; i < sequence.Count(); i++)
            {
                int decInt = sequence[i] ^ keys[slot];
                answer += decInt;
                char add = (char)decInt;
                decrypted += add;

                slot++;
                if (slot == 3) slot = 0;
            }


            return answer.ToString();
        }
    }
}
