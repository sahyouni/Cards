using System.Collections.Generic;

namespace Cards.Core.Hands
{
	/// <summary>
	/// Two cards of the same rank
	/// </summary>
	public class OnePair : Hand
	{
		public OnePair(IList<Card> cards) : base(cards)
		{
			HandType = HandType.OnePair;
		}
	}
}
