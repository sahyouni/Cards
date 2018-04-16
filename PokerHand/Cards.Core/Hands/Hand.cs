using System;
using System.Collections.Generic;

namespace Cards.Core.Hands
{
	/// <summary>
	/// a hand is a card collection of 5 cards.
	/// </summary>
	public class Hand : CardCollection
	{
		public Hand(IList<Card> cards) : base(cards)
		{
			if(cards ==null || cards.Count !=5)
				throw new ArgumentOutOfRangeException(nameof(cards));
		}

		protected HandType HandType { get; set; }
	}

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
		RoyalFlush = 9
	}
}
