using System.Collections.Generic;
using Cards.Core;
using Cards.Core.Games;
using NUnit.Framework;

namespace Cards.CoreTests
{
	class GameTests
	{
		private CardCollection _flushCardCollection = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Ace),
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Clubs, Value.Two),
			new Card(Suit.Clubs, Value.King),
			new Card(Suit.Clubs, Value.Nine)
		});


		private CardCollection _threeOfAKind = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Diamonds, Value.Three),
			new Card(Suit.Hearts, Value.Three),
			new Card(Suit.Clubs, Value.King),
			new Card(Suit.Clubs, Value.Nine)
		});


		private CardCollection _notAHandCardCollection1 = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Diamonds, Value.Five),
			new Card(Suit.Hearts, Value.Four),
			new Card(Suit.Spades, Value.King),
			new Card(Suit.Clubs, Value.Nine)
		});

		private CardCollection _notAHandCardCollection2 = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Diamonds, Value.Four),
			new Card(Suit.Hearts, Value.Eight),
			new Card(Suit.Hearts, Value.Ten),
			new Card(Suit.Clubs, Value.Nine)
		});


		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsOneHand()
		{
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_flushCardCollection);

			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection1);

			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_notAHandCardCollection2);

			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);

			Assert.AreEqual(player1.Id, actual.Id);
			Assert.AreEqual(player1.Name, actual.Name);
		}
	}
}
