using System.Collections.Generic;
using Cards.Core;
using Cards.Core.Cards;
using NUnit.Framework;

namespace Cards.CoreTests
{
	class GameTests
	{
		/// <summary>
		/// 5 cards same suit (all clubs here)
		/// </summary>
		private CardCollection _flushCardCollection = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Ace),
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Clubs, Value.Two),
			new Card(Suit.Clubs, Value.King),
			new Card(Suit.Clubs, Value.Nine)
		});


		/// <summary>
		/// three cards of same value (rank)
		/// </summary>
		private CardCollection _threeOfAKind = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Diamonds, Value.Three),
			new Card(Suit.Hearts, Value.Three),
			new Card(Suit.Clubs, Value.King),
			new Card(Suit.Clubs, Value.Nine)
		});

		/// <summary>
		/// two cards of same value (rank)
		/// </summary>
		private CardCollection _OnePair = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Diamonds, Value.Three),
			new Card(Suit.Hearts, Value.Four),
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

		private CardCollection _notAHandCardCollection3 = new CardCollection(new List<Card>
		{
			new Card(Suit.Clubs, Value.Three),
			new Card(Suit.Diamonds, Value.Four),
			new Card(Suit.Hearts, Value.Eight),
			new Card(Suit.Diamonds, Value.Ten),
			new Card(Suit.Clubs, Value.Nine)
		});

		#region three players with one holding a hand

		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsOneFlush()
		{
			//this has has a flush so s/he should win
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_flushCardCollection);

			//loser
			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection1);

			//loser
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_notAHandCardCollection2);

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);
			

			Assert.AreEqual(player1.Id, actual.Id);
			Assert.AreEqual(player1.Name, actual.Name);
		}

		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsThreeOfAKind()
		{
			//let's pretend this player does not have a hand
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_notAHandCardCollection1);

			//also a loser
			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection2);

			//this one should win since s/he a three of a kind
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_threeOfAKind);

			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);

			Assert.AreEqual(player3.Id, actual.Id);
			Assert.AreEqual(player3.Name, actual.Name);
		}

		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsOnePair()
		{
			//let's pretend this player does not have a hand
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_notAHandCardCollection1);

			//should be a winner (since in posession of one pair)
			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_OnePair);

			//loser
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_notAHandCardCollection1);

			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);

			Assert.AreEqual(player2.Id, actual.Id);
			Assert.AreEqual(player2.Name, actual.Name);
		}

		#endregion


		#region 5 players with two holding hands. The hand with the higher rank should win
		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsOnePairAndThreeOfAKind()
		{
			//player 2 should win
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_OnePair);

			//three of a kind wins
			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_threeOfAKind);

			//loser
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_notAHandCardCollection2);

			Player player4 = new Player { Id = 105, Name = "Player 4 " };
			player4.DealCards(_notAHandCardCollection1);

			Player player5 = new Player { Id = 106, Name = "Player 5" };
			player5.DealCards(_notAHandCardCollection2);

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);
			game.Players.Add(player4);
			game.Players.Add(player5);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);


			Assert.AreEqual(player2.Id, actual.Id);
			Assert.AreEqual(player2.Name, actual.Name);
		}

		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsOneFlushAndOnePair()
		{
			//flush has a rank of 5. should beat the pair
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_flushCardCollection);

			//pair would lose to player1
			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_OnePair);

			//loser
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_notAHandCardCollection2);

			Player player4 = new Player { Id = 105, Name = "Player 4 " };
			player4.DealCards(_notAHandCardCollection1);

			Player player5 = new Player { Id = 106, Name = "Player 5" };
			player5.DealCards(_notAHandCardCollection3);

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);
			game.Players.Add(player4);
			game.Players.Add(player5);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);


			Assert.AreEqual(player1.Id, actual.Id);
			Assert.AreEqual(player1.Name, actual.Name);
		}

		[Test]
		public void GetWinner_Returns_Winner_When_ThereIsOneFlushAndThreeOfAKind()
		{
			
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_threeOfAKind);

			//pair would lose to player1
			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection2);

			//make this guy the winner
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_flushCardCollection);

			Player player4 = new Player { Id = 105, Name = "Player 4 " };
			player4.DealCards(_notAHandCardCollection1);

			Player player5 = new Player { Id = 106, Name = "Player 5" };
			player5.DealCards(_notAHandCardCollection3);

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);
			game.Players.Add(player4);
			game.Players.Add(player5);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);


			Assert.AreEqual(player3.Id, actual.Id);
			Assert.AreEqual(player3.Name, actual.Name);
		}
		#endregion

		#region 4 players with three of them holding hands
		[Test]
		public void GetWinner_Returns_Winner_FromAmong_Three_Hands()
		{
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_threeOfAKind);

			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection2);

			//make this guy the winner
			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_flushCardCollection);

			Player player4 = new Player { Id = 105, Name = "Player 4 " };
			player4.DealCards(_OnePair);

			Player player5 = new Player { Id = 106, Name = "Player 5" };
			player5.DealCards(_notAHandCardCollection3);

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			game.Players.Add(player3);
			game.Players.Add(player4);
			game.Players.Add(player5);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);


			Assert.AreEqual(player3.Id, actual.Id);
			Assert.AreEqual(player3.Name, actual.Name);
		}
		#endregion

		[Test]
		public void GetWinner_Returns_Null_When_No_Hands_1()
		{
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_notAHandCardCollection1);

			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection2);

		

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);
			

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.GetType() == typeof(Player.NullPlayer));
		}

		[Test]
		public void GetWinner_Returns_Null_When_No_Hands_2()
		{
			Player player1 = new Player { Id = 100, Name = "John" };
			player1.DealCards(_notAHandCardCollection1);

			Player player2 = new Player { Id = 101, Name = "Jane" };
			player2.DealCards(_notAHandCardCollection2);

			Player player3 = new Player { Id = 104, Name = "Blah" };
			player3.DealCards(_notAHandCardCollection3);

			//create a game and add players to it
			PokerGame game = new PokerGame();
			game.Players.Add(player1);
			game.Players.Add(player2);

			var actual = game.GetWinner();

			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.GetType() == typeof(Player.NullPlayer));
		}
	}
}
