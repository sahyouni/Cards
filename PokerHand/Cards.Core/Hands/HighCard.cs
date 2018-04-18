using System.Collections.Generic;

namespace Cards.Core.Hands
{
	public class HighCard : Hand
	{
		public HighCard(IList<Card> cards) : base(cards)
		{
			HandType = HandType.HighCard;
		}
	}
}
