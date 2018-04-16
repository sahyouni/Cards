using System.Collections;
using System.Collections.Generic;

namespace Cards.Core.Games
{
	public abstract class Game
	{
		public abstract Player Add(Player player);

		public Player Winner { get; set; }

		public IList<Player> Players => throw new System.NotImplementedException();


		public Deck Deck { get; set; }
	}
}