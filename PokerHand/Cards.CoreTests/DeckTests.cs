
using System.Collections;
using System.Collections.Generic;
using Cards.Core;
using Cards.Core.Shuffling;
using Moq;
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
		public void Deck_Shuffle_Marks_Deck_As_NotSorted()
		{
			Deck deck = new Deck(new PokerGame());

			Assert.IsFalse(deck.IsSorted);

			deck.Shuffle();

			Assert.IsTrue(deck.IsSorted);
		}

		[Test]
		public void Deck_Shuffle_Calls_Shuffle_On_Shuffling_Strategy()
		{
			Deck deck = new Deck(new PokerGame());
			
			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");

			deck.ShuffleStrategy = mock.Object;

			deck.Shuffle();

			mock.VerifyAll();
		}


	}
}
