using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core.Shuffling
{
	public class FisherYatesStrategy : IShuffleStrategy
	{
		private readonly Random _randomGenerator = new Random();

		public void Shuffle(IList<Card> cards)
		{
			int n = cards.Count;

			while (n > 1)
			{
				n--;
				int k = _randomGenerator.Next(n + 1);

				Card value = cards[k];
				cards[k] = cards[n];
				cards[n] = value;
			}
		}
	}
}
