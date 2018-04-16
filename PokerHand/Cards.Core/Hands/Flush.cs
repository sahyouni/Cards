using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards.Core.Hands
{
	public class Flush : Hand
	{
		public Flush(IList<Card> cards) : base(cards, HandType.Flush)
		{
		}

		public override HandType HandType => Type;
	}
}
