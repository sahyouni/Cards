using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards.Core.Hands
{
	public class HighCard : Hand
	{
		public HighCard(IList<Card> cards) : base(cards, HandType.HighCard)
		{

		}

		public override HandType HandType => Type;
	}
}
