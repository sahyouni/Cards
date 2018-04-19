using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cards.Core.Cards;
using Cards.Core.Shuffling;

namespace Cards.Core
{
	/// <summary>
	/// represents a deck of cards. When initially created, the deck is sorted. Calling the Shuffle() method shuffles the cards in the deck
	/// </summary>
	public class Deck
	{
		private readonly PokerGame _pokerGame;

		private bool _isSorted;

		/// <summary>
		/// the cards in the deck. keeping this private to avoid other objects from messing with the cards
		/// </summary>
		private IList<Card> Cards { get; set; }

		/// <summary>
		/// this is a candidate for property DI
		/// </summary>
		public IShuffleStrategy ShuffleStrategy { get; set; }


		public bool IsSorted { get { return !_isSorted; } }

		public int CardsCount { get { return Cards.Count; } }

		#region private methods
		/// <summary>
		/// creates an ordered deck i.e. initializes the cards in the deck
		/// </summary>
		private void InitiliazeDeck()
		{
			Cards = new List<Card>();

			foreach (Suit s in Enum.GetValues(typeof(Suit)))
			{
				foreach (Value v in Enum.GetValues(typeof(Value)))
				{
					Cards.Add(new Card(s, v));
				}
			}
		}
		#endregion

		/// <summary>
		/// A deck can be created based on a game of poker
		/// </summary>
		/// <param name="pokerGame"></param>
		public Deck(PokerGame pokerGame)
		{
			_pokerGame = pokerGame;
			_isSorted = true;
			InitiliazeDeck();
		}


		#region public methods
		/// <summary>
		/// exchange each element with a randomly picked element
		/// </summary>
		public void Shuffle()
		{
			//default the strategy to fisher yates
			if (ShuffleStrategy == null)
				ShuffleStrategy = new FisherYatesStrategy();

			ShuffleStrategy.Shuffle(Cards);

			_isSorted = false;
		}

		/// <summary>
		/// picks a number of cards from the top of the deck
		/// </summary>
		/// <param name="number">the number of cards to pick from the deck</param>
		/// <returns>the collection of cards</returns>
		public CardCollection GetTopCards(int number)
		{
			//check if there are enough cards in the deck
			if (Cards.Count < number || number <= 0)
				throw new ArgumentException("cannot pick " + number + " from a deck that has " + Cards.Count + " card(s).");

			//make sure you pick from a shuffled deck
			if (_isSorted)
			{
				Shuffle();
			}

			IList<Card> result = new List<Card>(number);

			for (int i = 0; i < number; i++)
			{
				result.Add(Cards[i]);
				Cards.RemoveAt(0);
			}

			return new CardCollection(result);
		}
		
		/// <summary>
		/// pick a specific card from the deck
		/// </summary>
		/// <param name="card">the card we are looking for</param>
		/// <returns></returns>
		public Card FindCard(Card card)
		{
			//probably buggy
			return GetTopCards(1).Collection.FirstOrDefault(x => x.Equals(card));
		}

		public string DisplayDeck()
		{
			StringBuilder builder = new StringBuilder("Total cards in deck: " + Cards.Count + ". Is deck sorted?: " + _isSorted + Environment.NewLine);

			foreach (var card in Cards)
			{
				builder.Append(card);
				builder.Append(Environment.NewLine);
			}

			builder.Append("-----------------------");

			return builder.ToString();
		}

		#endregion
	}
}
