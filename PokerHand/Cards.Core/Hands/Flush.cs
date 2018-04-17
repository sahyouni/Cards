using System.Collections.Generic;

namespace Cards.Core.Hands
{
	/// <summary>
	/// Any five cards of the same suit, but not in a sequence. 
	/// </summary>
	public class Flush : Hand
	{
		public Flush(IList<Card> cards) : base(cards)
		{
			HandType = HandType.Flush;
		}
	}
}
