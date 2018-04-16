using System.Collections.Generic;

namespace Cards.Core.Hands
{

	public class OnePair : Hand
	{
		public OnePair(IList<Card> cards) : base(cards)
		{
			HandType = HandType.OnePair;
		}
	}
}
