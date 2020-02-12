using SortePerWpf.Model.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortePerWpf.Model.Game;

namespace SortePerWpf.ViewModel
{
    public class SortePerGameViewModel : BaseViewModel
    {
        public SortePerGame Game
        {
            get { return game; }
            private set { game = value; }
        }

        private SortePerGame game;

        public SortePerGameViewModel()
        {
            Game = new SortePerGame();
            Game.AddNewPlayer(new Player("Emil"));
            Game.Players[0].Add(new Model.Cards.Card(0));
            Game.Players[0].Add(new Model.Cards.Card(1));
            Game.Players[0].Add(new Model.Cards.Card(2));
            Game.Players[0].Add(new Model.Cards.Card(3));
            Game.Players[0].Add(new Model.Cards.Card(0));
            Game.Players[0].Add(new Model.Cards.Card(0));

            Game.AddNewPlayer(new Player("Hubba"));
        }


    }
}
