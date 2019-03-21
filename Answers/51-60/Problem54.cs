using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem54 : answerBaseClass
    {
        public override string GetAnswer()
        {
            string file = System.IO.File.ReadAllText(@"p054_poker.txt");

            string[] hands = file.Split(new char[] { '\n' } , StringSplitOptions.RemoveEmptyEntries);

            int p1Wins = 0;

            foreach(string hand in hands)
            {
                if (DoesPlayer1Win(hand))
                    p1Wins++;
            }



            return p1Wins.ToString();
        }

        private bool DoesPlayer1Win(string hand)
        {
            string[] rawCards = hand.ToUpper().Split(' ');

            string[] p1 = new string[5];
            string[] p2 = new string[5];
            Array.Copy(rawCards, 0, p1, 0, 5);
            Array.Copy(rawCards, 5, p2, 0, 5);

            Card[] p1Cards = p1.Select(s => new Card(s)).ToArray();
            Card[] p2Cards = p2.Select(s => new Card(s)).ToArray();

            Ranking p1Rank = new Ranking(p1Cards);
            Ranking p2Rank = new Ranking(p2Cards);

            return (p1Rank.CompareTo(p2Rank) > 0);
        }


        public class Card
        {
            public int rank;
            public int suit;
            public Card(string rawStr)
            {
                char rankChar = rawStr[0];
                if (rankChar >= '2' && rankChar <= '9')
                    this.rank = rankChar - '0';
                else
                {
                    if (rankChar == 'T') this.rank = 10;
                    if (rankChar == 'J') this.rank = 11;
                    if (rankChar == 'Q') this.rank = 12;
                    if (rankChar == 'K') this.rank = 13;
                    if (rankChar == 'A') this.rank = 14;
                }

                char suitChar = rawStr[1];
                this.suit = suitChar - 'A' + 1;

                if (this.rank == 0) throw new Exception("Was unable to determine rank");
            }
            public Card(int rank, int suit) { this.rank = rank;  this.suit = suit; }
            public override string ToString()
            {
                return rank.ToString() + (char)('A' + suit - 1);
            }
        }

        public class Ranking : IComparable<Ranking>
        {
            public int category;
            public int[] tieRanks;

            public Ranking(Card[] cards)
            {
                tieRanks = new int[5];

                if (cards.Length != 5) throw new Exception("Strange card count detected");

                int firstSuit = cards.First().suit;
                bool isFlush = cards.All(c => c.suit == firstSuit);

                List<IGrouping<int, Card>> rankGrouping = cards.GroupBy(c => c.rank).OrderBy(g => g.Count() * 100 + g.Key).Reverse().ToList();

                this.category = GetCategoryFromRankGrouping(rankGrouping, isFlush);

                for (int i = 0; i < rankGrouping.Count(); i++)
                    tieRanks[i] = rankGrouping[i].Key;

            }

            public int CompareTo(Ranking other)
            {
                if (this.category < other.category) return -1;
                if (this.category > other.category) return 1;

                for (int i = 0; i < 5; i++)
                    if (this.tieRanks[i] != other.tieRanks[i])
                        return this.tieRanks[i].CompareTo(other.tieRanks[i]);

                return 0;
            }

            private int GetCategoryFromRankGrouping(List<IGrouping<int, Card>> rankGrouping, bool isFlush)
            {

                if (rankGrouping.Count() < 2) throw new Exception("Impossible hand");

                bool isStraight = false;

                if (rankGrouping[0].Count() == 1)
                {
                    if (rankGrouping[0].Key == rankGrouping[4].Key + 4)
                        isStraight = true;
                    if (rankGrouping[0].Key == 14)
                        if (rankGrouping[1].Key == 5)
                            isStraight = true; // wraparound - 5,4,3,2,A
                }

                

                if (isStraight && isFlush) return 9;

                if (rankGrouping[0].Count() == 4) return 8;

                if (rankGrouping[0].Count() == 3 && rankGrouping[1].Count() == 2) return 7;
                if (isFlush) return 6;
                if (isStraight) return 5;
                if (rankGrouping[0].Count() == 3) return 4;
                if (rankGrouping[0].Count() == 2 && rankGrouping[1].Count() == 2) return 3;
                if (rankGrouping[0].Count() == 2) return 2;
                return 1;
            }

            public override string ToString()
            {
                return this.category + " :: " + tieRanks.Select(i => i.ToString()).Aggregate((a, b) => a + "," + b);
            }
        }

    }

    
}
