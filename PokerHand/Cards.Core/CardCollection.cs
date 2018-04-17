using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Core.Hands;

namespace Cards.Core
{
	public class CardCollection
	{
		protected readonly IList<Card> Cards;

		protected virtual void Validate()
		{
			
		}

		public CardCollection() { }

		public CardCollection(IList<Card> cards)
		{
			Cards = cards;

			if (Cards == null)
				throw new ArgumentOutOfRangeException(nameof(Cards));

			if (Cards.HasDuplicates())
				throw new ArgumentOutOfRangeException(nameof(Cards));
		}

		public IList<Card> Collection => Cards.ToList();

		//use ref to change the reference itself not the object
		public bool IsHand(ref Hand hand)
		{
			if (Cards == null || Cards.Count != 5)
				return false;


			if (IsFlush())
			{
				hand = new Flush(Cards);
				return true;
			}

			if (IsThreeOfAKind())
			{
				hand = new ThreeOfAKind(Cards);
				return true;
			}

			if (IsOnePair())
			{
				hand = new OnePair(Cards);
				return true;
			}

			return false;
		}

		private bool IsFlush()
		{
			return Cards.GroupBy(card => card.Suit).Count() == 1;
		}

		private bool IsOnePair()
		{
			return Cards.GroupBy(card => card.Value).Any(group => group.Count() == 2);
		}

		private bool IsThreeOfAKind()
		{
			return Cards.GroupBy(card => card.Value).Any(group => group.Count() >= 3);
		}
	}
}
