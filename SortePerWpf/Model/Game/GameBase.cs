using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortePerWpf.Model.Players;

namespace SortePerWpf.Model.Game
{
    public abstract class GameBase
    {
        /// <summary>
        /// The current players in the game
        /// </summary>
        public List<Player> Players
        {
            get { return players; }
            protected set { players = value; }
        }

        private List<Player> players;

        public GameBase()
        {
            Players = new List<Player>();
        }

        /// <summary>
        /// Adds a new player to the game
        /// </summary>
        /// <param name="player"></param>
        public void AddNewPlayer(Player player)
        {
            Players.Add(player);
        }

        /// <summary>
        /// Removes a player from the game
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        /// <summary>
        /// Should be called when the game starts
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Should be called when an player is changing turn
        /// </summary>
        public abstract void ChangeTurn();

        /// <summary>
        /// Should be called when the game ends
        /// </summary>
        public abstract void End();
    }
}
