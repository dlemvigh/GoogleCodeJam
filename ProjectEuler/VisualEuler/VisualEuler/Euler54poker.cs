using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEuler
{
    partial class Euler
    {

        public static void Euler54(string input)
        {
            var count = 0;
            var hands = input.Split('\n');
            foreach (string hand in hands)
            {
                var cards = hand.Split(' ').Select(x => Card.ParseCard(x));
                var hand1 = new Hand(cards.Take(5));
                var hand2 = new Hand(cards.Skip(5).Take(5));
                var winner = HandCompare.Compare(hand1, hand2);
                if (winner == 1)
                {
                    count++;
                }
            }
            var result = count;

        }
    }

    public static class HandCompare
    {
        /// <summary>
        /// Determines winner between two hands
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns>0 - draw. 1 - player 1 wins. 2 - Player 2 wins</returns>
        public static int Compare(Hand h1, Hand h2)
        {
            if (h1.Rank != h2.Rank)
            {
                return h1.Rank < h2.Rank ? 1 : 2;
            }

            switch (h1.Rank)
            {
                case HandRank.StraightFlush:
                    return CompareStraight(h1, h2);
                case HandRank.FullHouse:
                    return ComparePairs(h1, h2);
                case HandRank.Flush:
                    return CompareHighCard(h1, h2);
                case HandRank.Straigh:
                    return CompareStraight(h1, h2);
                case HandRank.Three:
                    return ComparePairs(h1, h2);
                case HandRank.TwoPairs:
                    return ComparePairs(h1, h2);
                case HandRank.Pair:
                    return ComparePairs(h1, h2);
                case HandRank.None:
                    return CompareHighCard(h1, h2);
                default:
                    break;
            }
            return 0;
        }

        public static int ComparePairs(Hand h1, Hand h2)
        {
            return CompareRank(SortByPairs(h1), SortByPairs(h2));
        }

        public static IEnumerable<Card>SortByPairs(Hand hand)
        {
            var cards = hand.Cards
                .OrderByDescending(x => x.Rank)
                .GroupBy(x => x.Rank)
                .OrderByDescending(x => x.Count())
                .SelectMany(x => x);
            return cards;
        }

        public static int CompareStraight(Hand h1, Hand h2)
        {
            throw new NotImplementedException();
        }

        public static int CompareHighCard(Hand h1, Hand h2)
        {
            var cards1 = h1.Cards.OrderByDescending(x => x.Rank);
            var cards2 = h2.Cards.OrderByDescending(x => x.Rank);
            return CompareRank(cards1, cards2);
        }

        private static int CompareRank(IEnumerable<Card> h1, IEnumerable<Card> h2)
        {
            return CompareRank(h1.ToList(), h2.ToList());
        }

        private static int CompareRank(IList<Card> h1, IList<Card> h2)
        {
            for(var i = 0; i < h1.Count(); i++)
            {
                if (h1[i].Rank > h2[i].Rank)
                {
                    return 1;
                }
                if (h1[i].Rank < h2[i].Rank)
                {
                    return 2;
                }
            }
            return 0;
        }
    }

    public class Hand
    {
        public IEnumerable<Card> Cards { get; private set; }
        public HandRank Rank { get; private set; }

        public Hand(IEnumerable<Card> cards)
        {
            if (cards == null || cards.Count() != 5)
            {
                throw new ArgumentException("expected hand with 5 cards");
            }
            Cards = cards;
            Rank = GetHandRank();
        }

        public override string ToString()
        {
            return string.Join(" ", Cards);
        }

        public IEnumerable<int> GetPairs()
        {
            return Cards
                .GroupBy(x => x.Rank)
                .Where(x => x.Count() == 2)
                .OrderByDescending(x => x.Key)
                .Select(x => x.Key);
        }

        public bool HasPair()
        {
            return Cards
                .GroupBy(x => x.Rank)
                .Any(x => x.Count() == 2);

        }

        public bool HasThree()
        {
            return Cards
                .GroupBy(x => x.Rank)
                .Any(x => x.Count() == 3);
        }

        public bool HasFour()
        {
            return Cards
                .GroupBy(x => x.Rank)
                .Any(x => x.Count() == 4);
        }

        public bool IsFlush()
        {
            return Cards.GroupBy(x => x.Suit).Count() == 1;
        }

        public bool IsStraight()
        {
            var ordered = Cards.OrderBy(x => x.Rank).Select(x => x.Rank);

            var hasAce = ordered.Any(x => x == 14);
            if (hasAce)
            {
                bool aceLow = Enumerable.SequenceEqual(ordered, Enumerable.Range(1, 5));
                bool aceHigh = Enumerable.SequenceEqual(ordered, Enumerable.Range(10, 5));
                return aceLow || aceHigh;
            }
            else
            {
                var low = ordered.First();
                bool isSequence = Enumerable.SequenceEqual(ordered, Enumerable.Range(low, 5));
                return isSequence;
            }

        }

        public HandRank GetHandRank()
        {
            var straight = IsStraight();
            var flush = IsFlush();

            var two = HasPair();
            var three = HasThree();
            var four = HasFour();
            var pairs = GetPairs().Count();

            return (straight && flush) ? HandRank.StraightFlush :
                (two && three) ? HandRank.FullHouse :
                flush ? HandRank.Flush :
                straight ? HandRank.Straigh :
                three ? HandRank.Three :
                pairs == 2 ? HandRank.TwoPairs :
                pairs == 1? HandRank.Pair :
                HandRank.None;
        }
    }

    public class Card
    {
        public char Suit { get; private set; }
        public int Rank { get; private set; }

        public Card() { }

        public Card(string card)
        {
            if (string.IsNullOrEmpty(card) || card.Length != 2)
            {
                throw new ArgumentException("card input must be a string of length 2");
            }
            Rank = GetRank(card[0]);
            Suit = card[1];
        }

        public static Card ParseCard(string card)
        {
            if (string.IsNullOrEmpty(card) || card.Length != 2)
            {
                throw new ArgumentException("card input must be a string of length 2");
            }
            return new Card
            {
                Rank = GetRank(card[0]),
                Suit = card[1]
            };

        }

        public static int GetRank(char rank)
        {
            switch (rank)
            {
                case 'T':
                    return 10;
                case 'J':
                    return 11;
                case 'Q':
                    return 12;
                case 'K':
                    return 13;
                case 'A':
                    return 14;
                default:
                    return int.Parse(rank.ToString());
            }
        }

        public override string ToString()
        {
            return Rank + "" + Suit;
        }
    }

    public enum HandRank
    {
        StraightFlush,
        FullHouse,
        Flush,
        Straigh,
        Three,
        TwoPairs,
        Pair,
        None
    }
}
