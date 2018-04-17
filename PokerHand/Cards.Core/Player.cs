using System;
using System.Collections;
using System.Collections.Generic;
using Cards.Core.Hands;

namespace Cards.Core
{
	public class Player
	{
		public int Id { get; set; }

		public virtual string Name { get; set; }

		public virtual CardCollection CurrentCards { get; private set; }

		public Hand GetCurrentHandOrNull()
		{
			Hand hand = null;
			if (CurrentCards.IsHand(ref hand))
			{
				return hand;
			}

			return new NullHand();
		}

		public void DealCards(CardCollection collection)
		{
			CurrentCards = collection;
		}

		public void ResetCards()
		{
			CurrentCards.Collection.Clear();
		}

		public override string ToString()
		{
			string result = "Player Id: " + Id + ". Name: " + Name + " Number of Cards: " + CurrentCards.Collection.Count + Environment.NewLine;

			foreach (var card in CurrentCards.Collection)
			{
				result += card;
				result += Environment.NewLine;
			}
			return result;
		}
	}

	public class NoPlayer : Player
	{
		public override string Name => "N/A";

		public override CardCollection CurrentCards => new CardCollection(null);
	}
}
