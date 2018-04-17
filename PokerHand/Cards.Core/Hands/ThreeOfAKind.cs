using System.Collections.Generic;

namespace Cards.Core.Hands
{

	/// <summary>
	/// Three cards of the same rank
	/// </summary>
	public class ThreeOfAKind : Hand
	{
		public ThreeOfAKind(IList<Card> cards) : base(cards)
		{
			HandType = HandType.ThreeOfKind;
		}
	}
}
