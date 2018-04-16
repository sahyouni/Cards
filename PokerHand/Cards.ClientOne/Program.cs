using System;
using Cards.Core;
using Cards.Core.Games;


namespace Cards.ClientOne
{
	class Program
	{
		static void Main(string[] args)
		{
			Game pokerGame = new PokerGame();
			var player1 = pokerGame.Add(new Player { Id = 1, Name = "Rami" });
			var player2 = pokerGame.Add(new Player { Id = 2, Name = "John" });


			Deck deck = new Deck(pokerGame);

			Console.WriteLine(deck.DisplayDeck());

			deck.Shuffle();

			Console.WriteLine(deck.DisplayDeck());

			CardCollection cards = deck.Pick(5);

			player1.DealCards(cards);
			Console.WriteLine(player1);
			Console.WriteLine(deck.DisplayDeck());


			player2.DealCards(deck.Pick(5));
			Console.WriteLine(player2);
			Console.WriteLine(deck.DisplayDeck());

			Console.ReadLine();
		}


		static void DisplayPlayerCards(Player player)
		{
			Console.WriteLine("Displaying Player " + player.Name + " cards:");

			foreach (var card in player.CurrentCards)
			{
				Console.WriteLine(card);
			}

			Console.WriteLine("-------------------");

		}
	}
}
