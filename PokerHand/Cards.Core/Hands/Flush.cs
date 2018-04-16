﻿using System.Collections.Generic;

namespace Cards.Core.Hands
{
	public class Flush : Hand
	{
		public Flush(IList<Card> cards) : base(cards)
		{
			HandType = HandType.Flush;
		}
	}
}
