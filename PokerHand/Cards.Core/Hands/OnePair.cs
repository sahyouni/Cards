using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards.Core.Hands
{

	public class OnePair : Hand
	{
		public OnePair(IList<Card> cards) : base(cards, HandType.OnePair)
		{
		}

		public override HandType HandType => Type;
	}
}
