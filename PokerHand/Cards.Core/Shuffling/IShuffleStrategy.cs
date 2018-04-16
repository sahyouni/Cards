using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core.Shuffling
{
	/// <summary>
	/// strategy pattern
	/// </summary>
	public interface IShuffleStrategy
	{
		void Shuffle(IList<Card> cards);
	}
}
