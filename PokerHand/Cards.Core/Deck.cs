using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Cards.Core.Games;
using Cards.Core.Hands;
using Cards.Core.Shuffling;

namespace Cards.Core
{
	public class Deck
	{
		private readonly PokerGame _pokerGame;

		private bool _isSorted;

		private readonly Random _randomGenerator = new Random();

		public IList<Card> Cards { get; set; }

		public IShuffleStrategy ShuffleStrategy { get; set; }

		public Deck(PokerGame pokerGame)
		{
			_pokerGame = pokerGame;
			_isSorted = true;
			InitiliazeDeck();
		}

		/// <summary>
		/// creates an ordered deck
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
		/// <param name="number"></param>
		/// <returns></returns>
		public CardCollection Pick(int number)
		{
			//check if there are enough cards in the deck
			if(Cards.Count < number)
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
	}
}
