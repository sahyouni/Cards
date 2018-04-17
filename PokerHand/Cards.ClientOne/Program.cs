using System;
using System.Collections.Generic;
using Cards.Core;
using Cards.Core.Games;
using Cards.Core.Hands;


namespace Cards.ClientOne
{
	class Program
	{
		public static Flush SampleFlush = new Flush(new List<Card>
		{
			new Card(Suit.Clubs, Value.Two),
			new Card(Suit.Clubs, Value.Five),
			new Card(Suit.Clubs, Value.Seven),
			new Card(Suit.Clubs, Value.Eight),
			new Card(Suit.Clubs, Value.Ten)
		});

		static void Main(string[] args)
		{
			PokerGame pokerPokerGame = new PokerGame();
			var player1 = pokerPokerGame.Add(new Player { Id = 1, Name = "Rami" });
			var player2 = pokerPokerGame.Add(new Player { Id = 2, Name = "John" });


			Deck deck = new Deck(pokerPokerGame);

			//display initial deck
			Console.WriteLine(deck.DisplayDeck());

			deck.Shuffle();

			//display shuffled deck
			Console.WriteLine(deck.DisplayDeck());

			//pick 5 cards from deck
			CardCollection cards = deck.Pick(5);

			//distribute cards to player 1
			player1.DealCards(cards);
			Console.WriteLine(player1);

			//make sure deck is properly updated
			Console.WriteLine(deck.DisplayDeck());

			//distribute another 5 cards to player 2
			player2.DealCards(deck.Pick(5));
			Console.WriteLine(player2);

			//make sure deck is properly updated again
			Console.WriteLine(deck.DisplayDeck());

			//fake a flush
			player1.ResetCards();
			player1.DealCards(SampleFlush);
			Console.WriteLine(player1);

			Hand hand = null;

			bool hasAHand = player1.CurrentCards.IsHand(ref hand);

			if (hasAHand)
			{
				Console.WriteLine(hand.Rank);
			}

			Console.ReadLine();
		}
	}
}
