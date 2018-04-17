using System;
using System.Collections.Generic;

namespace Cards.Core.Hands
{
	/// <summary>
	/// a hand is a card collection of 5 cards.
	/// </summary>
	public class Hand : CardCollection, IComparable<Hand>
	{

		protected override void Validate()
		{
			if (Cards == null || Cards.Count != 5)
				throw new ArgumentOutOfRangeException(nameof(Cards));
		}

		public Hand()
		{
		}

		public Hand(IList<Card> cards) : base(cards)
		{
			
		}

		public HandType HandType { get; set; }

		public int Rank => (int)HandType;
		public int CompareTo(Hand other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;

			return Rank.CompareTo(other.Rank);
		}
	}

	public class NullHand : Hand
	{
		protected override void Validate()
		{
			
		}

		public NullHand()
		{
			
		}

		public NullHand(IList<Card> cards) : base(new List<Card>())
		{
			HandType = HandType.Unknown;
		}
	}

	/// <summary>
	/// define an enumeration that defines the hands along with the rank of each hand. sorted ascending. bigger is better
	/// </summary>
	public enum HandType
	{
		HighCard = 0,
		OnePair = 1,
		TwoPair = 2,
		ThreeOfKind = 3,
		Straight = 4,
		Flush = 5,
		FullHouse = 6,
		FourOfAKind = 7,
		StraightFlush = 8,
		RoyalFlush = 9,
		Unknown = -1
	}
}
