
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

		[Test]
		public void Deck_GetTopCards_Throws_When_NumberofCards_IsZero()
		{
			Deck deck = new Deck(new PokerGame());

			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");

			Assert.That(() => deck.GetTopCards(0), Throws.ArgumentException);
		}

		[Test]
		public void Deck_GetTopCards_Throws_When_NumberofCards_IsGreaterThan_52()
		{
			Deck deck = new Deck(new PokerGame());

			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");

			Assert.That(() => deck.GetTopCards(53), Throws.ArgumentException);
		}

		[Test]
		public void Deck_GetTopCards_Shuffles_The_Deck()
		{
			Deck deck = new Deck(new PokerGame());

			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");


			Assert.IsFalse(deck.IsSorted);

			var cards = deck.GetTopCards(2);

			Assert.IsTrue(deck.IsSorted);
		}

		[Test]
		public void Deck_FindCard_Returns_A_Card_When_Card_IsInDeck()
		{
			Deck deck = new Deck(new PokerGame());

			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");

			var actual = deck.FindCard(new Card(Suit.Spades, Value.Ace));

			Assert.AreEqual(Value.Ace, actual.Value);

			Assert.AreEqual(Suit.Spades, actual.Suit);
		}

		[Test]
		public void Deck_FindCard_Returns_A_Card_When_Card_IsInNotDeck()
		{
			Deck deck = new Deck(new PokerGame());

			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");

			var actual = deck.FindCard(new Card(Suit.Spades, Value.Ace));

			Assert.AreEqual(Value.Ace, actual.Value);

			Assert.AreEqual(Suit.Spades, actual.Suit);
		}

		[Test]
		public void Deck_FindCard_Returns_Updates_CardCount_When_CardIsFound()
		{
			Deck deck = new Deck(new PokerGame());

			var mock = new Mock<IShuffleStrategy>();
			mock.Setup(x => x.Shuffle(It.IsAny<IList<Card>>())).Verifiable("shuffle was not called on strategy");

			Assert.AreEqual(52, deck.CardsCount);

			var actual = deck.FindCard(new Card(Suit.Spades, Value.Ace));

			Assert.AreEqual(51, deck.CardsCount);
		}

	}
}
