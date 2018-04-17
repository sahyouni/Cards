using System.Collections.Generic;
using Cards.Core;
using Cards.Core.Hands;
using NUnit.Framework;

namespace Cards.CoreTests
{
	public class CardCollectionTests
	{
		#region IsHand() - collection is NOT a hand

		[Test]
		public void IsHand_Returns_False_When_CardCollectionCount_IsNot5()
		{
			//a collection that is not a hand
			IList<Card> cards = new List<Card>
			{
				new Card(Suit.Clubs, Value.Ace),
				new Card(Suit.Diamonds, Value.Ace),
				new Card(Suit.Clubs, Value.Two)
			};

			CardCollection target = new CardCollection(cards);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsFalse(actual);

			Assert.IsNull(hand);
		}

		[Test]
		public void IsHand_Returns_False_When_CardCollection_IsNotAHand_1()
		{
			//a collection that is not a hand
			IList<Card> cards = new List<Card>
			{
				new Card(Suit.Clubs, Value.Ace),
				new Card(Suit.Diamonds, Value.Queen),
				new Card(Suit.Clubs, Value.Two),
				new Card(Suit.Clubs, Value.King)
			};


			CardCollection target = new CardCollection(cards);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsFalse(actual);

			Assert.IsNull(hand);
		}

		[Test]
		public void IsHand_Returns_False_When_CardCollection_IsNotAHand_2()
		{
			//a collection that is not a hand
			IList<Card> cards = new List<Card>
			{
				new Card(Suit.Clubs, Value.Three),
				new Card(Suit.Diamonds, Value.Queen),
				new Card(Suit.Clubs, Value.Two),
				new Card(Suit.Clubs, Value.King)
			};


			CardCollection target = new CardCollection(cards);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsFalse(actual);

			Assert.IsNull(hand);
		}

		[Test]
		public void IsHand_Returns_False_When_CardCollectionCount_IsNull()
		{
			CardCollection target = new CardCollection(null);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsFalse(actual);

			Assert.IsNull(hand);
		}

		#endregion

		#region IsHand() - collection is a hand
		[Test]
		public void IsHand_Returns_True_When_CardCollection_Is_A_Flush()
		{
			//a collection that is a flush
			IList<Card> cards = new List<Card>
			{
				new Card(Suit.Clubs, Value.Ace),
				new Card(Suit.Clubs, Value.Three),
				new Card(Suit.Clubs, Value.Two),
				new Card(Suit.Clubs, Value.King),
				new Card(Suit.Clubs, Value.Nine)
			};

			CardCollection target = new CardCollection(cards);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsTrue(actual);

			Assert.IsNotNull(hand);

			
			Assert.AreEqual(5, hand.Rank);
			Assert.AreEqual(HandType.Flush, hand.HandType);

		}

		[Test]
		public void IsHand_Returns_True_When_CardCollection_Is_A_ThreeOfAKind()
		{
			//a collection that is three of a kind
			IList<Card> cards = new List<Card>
			{
				new Card(Suit.Clubs, Value.Three),
				new Card(Suit.Diamonds, Value.Three),
				new Card(Suit.Hearts, Value.Three),
				new Card(Suit.Clubs, Value.King),
				new Card(Suit.Clubs, Value.Nine)
			};

			CardCollection target = new CardCollection(cards);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsTrue(actual);

			Assert.IsNotNull(hand);


			Assert.AreEqual(3, hand.Rank);
			Assert.AreEqual(HandType.ThreeOfKind, hand.HandType);

		}

		[Test]
		public void IsHand_Returns_True_When_CardCollection_Is_A_OnePair()
		{
			//a collection that is a flush
			IList<Card> cards = new List<Card>
			{
				new Card(Suit.Clubs, Value.Three),
				new Card(Suit.Diamonds, Value.Three),
				new Card(Suit.Hearts, Value.Nine),
				new Card(Suit.Clubs, Value.King),
				new Card(Suit.Clubs, Value.Nine)
			};

			CardCollection target = new CardCollection(cards);
			Hand hand = null;
			bool actual = target.IsHand(ref hand);

			Assert.IsTrue(actual);

			Assert.IsNotNull(hand);


			Assert.AreEqual(1, hand.Rank);
			Assert.AreEqual(HandType.OnePair, hand.HandType);

		}
		#endregion
	}
}
