using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards.Core.Hands
{

	public class ThreeOfAKind : Hand
	{
		public ThreeOfAKind(IList<Card> cards) : base(cards, HandType.ThreeOfKind)
		{
		}

		public override HandType HandType => Type;
	}
}
