﻿namespace Cards.Core
{
	/// <summary>
	/// represents a card. Has a Suit and a Value. For example, Ace of Spades
	/// </summary>
	public class Card
	{
		public Card(Suit suit, Value value)
		{
			Suit = suit;
			Value = value;
		}


		/// <summary>
		/// A suit such as Hearts, Spaces etc..
		/// </summary>
		public Suit Suit { get; }

		/// <summary>
		/// the value of the card
		/// </summary>
		public Value Value { get; }

		public override string ToString()
		{
			return Value + " of " + Suit;
		}
	}

	public enum Suit
	{
		Hearts,
		Diamonds,
		Clubs,
		Spades
	}

	public enum Value
	{
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Ten = 10,
		Jack = 11,
		Queen = 12,
		King = 13,
		Ace = 14
	}
}
