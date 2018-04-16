using System;
using System.Collections;
using System.Collections.Generic;

namespace Cards.Core
{
	public class Player
	{
		public int Id { get; set; }

		public string Name { get; set;  }

		public IList<Card> CurrentCards { get;  private set; }

		public void DealCards(CardCollection collection)
		{
			CurrentCards = collection.Collection;
		}

		public override string ToString()
		{
			string result = "Player Id: " + Id + ". Name: " + Name + Environment.NewLine;

			foreach (var card in CurrentCards)
			{
				result += card;
				result += Environment.NewLine;
			}
			return result;
		}
	}
}
