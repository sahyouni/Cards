using System.Collections.Generic;
using System.Linq;
using Cards.Core.Hands;

namespace Cards.Core
{
	/// <summary>
	/// A game of poker
	/// </summary>
	public class PokerGame
	{
		private readonly IList<Player> _players = new List<Player>();

		public Player Add(Player player)
		{
			_players.Add(player);
			return player;
		}

		public Player GetWinner()
		{
			SortedList<Hand, Player> hands = new SortedList<Hand, Player>();
			foreach (var p in _players)
			{
				Hand h = p.GetCurrentHandOrNull();

				if (!(h is Hand.NullHand))
					hands.Add(h, p);
			}

			if(hands.Count ==0)
				return Player.UnknownPlayer;

			//top player
			Player topRankPlayer = hands.Last().Value;
		
			return topRankPlayer;
		}

		public IList<Player> Players => _players;


		public Deck Deck { get; set; }
	}
}