﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards.Core
{
	public class Card
	{
		public Card(Suit suit, Value value)
		{
			Suit = suit;
			Value = value;
		}

		public Suit Suit { get; }

		public Value Value { get; }
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
