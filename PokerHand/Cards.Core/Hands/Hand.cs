using System.Collections.Generic;

namespace PlayingCards.Core.Hands
{
	public abstract class Hand
	{
		private readonly IList<Card> _cards;

		protected readonly HandType Type;

		public abstract HandType HandType { get; }

		protected Hand(IList<Card> cards, HandType type)
		{
			_cards = cards;
			Type = type;
		}
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
