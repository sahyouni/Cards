using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Core.Hands;

namespace Cards.Core
{
	public class CardCollection
	{
		protected readonly IList<Card> Cards;

		public CardCollection(IList<Card> cards)
		{
			Cards = cards;
		}

		public IList<Card> Collection => Cards.ToList().AsReadOnly();

		//use ref to change the reference itself not the object
		public bool IsHand(ref Hand hand)
		{
			bool result = false;

			//check if flush
			if (Cards.GroupBy(card => card.Suit).Count() == 1)
			{
				result = true;
				hand = new Flush(Cards);
			}

			return result;
		}
	}
}
