using System.Collections.Generic;
using System.Linq;
using Cards.Core;

using Cards.Core.Hands;
using NUnit.Framework;

namespace Cards.CoreTests
{

	public class HandTests
	{
		[Test]
		public void Hands_Sorted_In_Correct_Order_1()
		{
			//create three hands
			Hand flush = new Flush(new List<Card>());
			Hand onePair = new OnePair(new List<Card>());
			Hand threeOfAKind = new ThreeOfAKind(new List<Card>());
			Hand highCard = new HighCard(new List<Card>());

			IList<Hand> hands = new List<Hand> { threeOfAKind, onePair, flush, highCard };

			//verify unsorted order
			Assert.AreEqual(0, hands.IndexOf(threeOfAKind));
			Assert.AreEqual(1, hands.IndexOf(onePair));
			Assert.AreEqual(2, hands.IndexOf(flush));

			hands.ToList().Sort();

			Assert.AreEqual(0, hands.IndexOf(threeOfAKind));
			Assert.AreEqual(1, hands.IndexOf(onePair));
			Assert.AreEqual(2, hands.IndexOf(flush));
		}

		[Test]
		public void Hands_Sorted_In_Correct_Order_2()
		{
			//create three hands
			Hand flush = new Flush(new List<Card>());
			Hand onePair = new OnePair(new List<Card>());
			Hand threeOfAKind = new ThreeOfAKind(new List<Card>());
			Hand highCard = new HighCard(new List<Card>());

			IList<Hand> hands = new List<Hand> { onePair, threeOfAKind, flush, highCard };

			//verify unsorted order
			Assert.AreEqual(0, hands.IndexOf(threeOfAKind));
			Assert.AreEqual(1, hands.IndexOf(onePair));
			Assert.AreEqual(2, hands.IndexOf(flush));

			hands.ToList().Sort();

			Assert.AreEqual(0, hands.IndexOf(threeOfAKind));
			Assert.AreEqual(1, hands.IndexOf(onePair));
			Assert.AreEqual(2, hands.IndexOf(flush));
		}

		[Test]
		public void Hands_Sorted_In_Correct_Order_3()
		{
			//create three hands
			Hand flush = new Flush(new List<Card>());
			Hand onePair = new OnePair(new List<Card>());
			Hand threeOfAKind = new ThreeOfAKind(new List<Card>());
			Hand highCard = new HighCard(new List<Card>());

			IList<Hand> hands = new List<Hand> { onePair, flush, highCard, threeOfAKind };

			//verify unsorted order
			Assert.AreEqual(0, hands.IndexOf(threeOfAKind));
			Assert.AreEqual(1, hands.IndexOf(onePair));
			Assert.AreEqual(2, hands.IndexOf(flush));

			hands.ToList().Sort();

			Assert.AreEqual(0, hands.IndexOf(threeOfAKind));
			Assert.AreEqual(1, hands.IndexOf(onePair));
			Assert.AreEqual(2, hands.IndexOf(flush));
		}
	}
}
