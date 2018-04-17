using System;
using Cards.Core.Cards;
using Cards.Core.Hands;

namespace Cards.Core
{
	/// <summary>
	/// represents a player in a game of poker
	/// </summary>
	public class Player
	{
		public int Id { get; set; }

		public virtual string Name { get; set; }

		/// <summary>
		/// the cards that the player is holding
		/// </summary>
		public virtual CardCollection CurrentCards { get; private set; }

		/// <summary>
		/// Used to check if the player is holding a hand or not. If true, the Hand is returned. Otherwise, a NullHand is returned
		/// </summary>
		/// <returns></returns>
		public Hand GetCurrentHandOrNull()
		{
			Hand hand = null;
			CurrentCards.IsHand(ref hand);
			return hand;
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

		public static Player UnknownPlayer => new NullPlayer();

		public class NullPlayer : Player
		{
			public override string Name => "N/A";

			public override CardCollection CurrentCards => new CardCollection(null);
		}
	}

}
