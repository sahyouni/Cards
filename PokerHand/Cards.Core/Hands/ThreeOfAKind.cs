using System.Collections.Generic;

namespace Cards.Core.Hands
{

	public class ThreeOfAKind : Hand
	{
		public ThreeOfAKind(IList<Card> cards) : base(cards)
		{
			HandType = HandType.ThreeOfKind;
		}
	}
}
