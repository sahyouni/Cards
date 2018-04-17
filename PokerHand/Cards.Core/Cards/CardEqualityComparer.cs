using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core
{
	public class CardEqualityComparer : EqualityComparer<Card>
	{
		public override bool Equals(Card x, Card y)
		{
			//card a equals card b if they have the same suit and value. nulls are not equal
			if (x == null || y == null)
				return false;

			return x.Suit == y.Suit && x.Value == y.Value;
		}

		public override int GetHashCode(Card obj)
		{
			//when two cards are equal, they should return the same hashcode. The opposite is not always true.
			return obj.GetHashCode();
		}
	}
}
