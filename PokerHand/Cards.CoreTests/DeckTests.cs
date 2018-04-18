
using Cards.Core;
using Cards.Core.Shuffling;
using NUnit.Framework;

namespace Cards.CoreTests
{

	public class DeckTests
	{
		/// <summary>
		/// unit testing is not the appropriate test for randomness - writing this just to verify the target code
		/// is calling the Random Strategy correctly
		/// </summary>
		[Test]
		public void Deck_Can_Shuffle()
		{
			Deck target = new Deck(new PokerGame())
			{
				ShuffleStrategy = new FisherYatesStrategy()
			};

			var orderDeck = target.DisplayDeck();

			target.Shuffle();

			var shuffleDeck = target.DisplayDeck();

		}

		[Test]
		public void Deck_Shuffles()
		{

		}
	}
}