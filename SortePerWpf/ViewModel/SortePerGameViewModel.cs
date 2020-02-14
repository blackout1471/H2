using SortePerWpf.Model.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortePerWpf.Model.Game;
using System.Windows.Input;
using SortePerWpf.Model;
using System.Windows.Controls;
using SortePerWpf.UserControls;
using SortePerWpf.Model.Cards;

namespace SortePerWpf.ViewModel
{
    public class SortePerGameViewModel : BaseViewModel
    {

        #region Commands
        /// <summary>
        /// The command for when current player is hovering
        /// </summary>
        public ICommand HoverCurrentPlayerCommand => new RelayCommand((args) =>
        {
            ImageEventArgs arg = (ImageEventArgs)args;
            Canvas.SetBottom(arg.Image, 20);
            Canvas.SetZIndex(arg.Image, 1);
        });

        /// <summary>
        /// The command for when current player leaves a image
        /// </summary>
        public ICommand UnHoverCurrentPlayerCommand => new RelayCommand((args) =>
        {
            ImageEventArgs arg = (ImageEventArgs)args;

            if (!upheldCards.Exists((x) => x.Position == arg.Position))
                Canvas.SetBottom(arg.Image, 0);

            Canvas.SetZIndex(arg.Image, 0);
        });

        /// <summary>
        /// Called when the current player click it's own cards
        /// </summary>
        public ICommand ClickCardCurrentPlayerCommand => new RelayCommand((args) =>
        {
            ImageEventArgs arg = (ImageEventArgs)args;
            AddCardToPairs(arg);

            if (upheldCards.Count == 2)
                if (IsPairAnMatch())
                    RemoveCurrentPair();
                else
                    NormaliseNotPairs();

            OnPropertyChanged(null);
        });

        /// <summary>
        /// When hovering over the opponents cards
        /// </summary>
        public ICommand HoverOpponentPlayerCommand => new RelayCommand((args) =>
        {
            ImageEventArgs arg = (ImageEventArgs)args;
            Canvas.SetBottom(arg.Image, 20);
            Canvas.SetZIndex(arg.Image, 1);
        });

        /// <summary>
        /// When leaving the hovered card
        /// </summary>
        public ICommand UnHoverOpponentPlayerCommand => new RelayCommand((args) =>
        {
            ImageEventArgs arg = (ImageEventArgs)args;
            Canvas.SetBottom(arg.Image, 0);
            Canvas.SetZIndex(arg.Image, 0);
        });

        /// <summary>
        /// Called when clicking opponents cards
        /// </summary>
        public ICommand ClickCardOpponentPlayerCommand => new RelayCommand((args) =>
        {
            ImageEventArgs arg = (ImageEventArgs)args;

            Game.DrawFromOpponent(arg.Position);
            CanPlayerDrawCard = false;

            OnPropertyChanged(null);
        });

        /// <summary>
        /// End the turn command
        /// </summary>
        public ICommand EndTurnCommand => new RelayCommand((o) => ChangeTurns());

        #endregion

        /// <summary>
        /// The current opponent
        /// </summary>
        public Player OpponentPlayer
        {
            get { return opponentPlayer; }
            set 
            {
                if (value == opponentPlayer)
                    return;

                opponentPlayer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The current player
        /// </summary>
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set 
            {
                if (value == currentPlayer)
                    return;

                currentPlayer = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Whether the current player has drawn card
        /// </summary>
        public bool CanPlayerDrawCard
        {
            get { return canPlayerDrawCard; }
            private set { 
                canPlayerDrawCard = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The current game
        /// </summary>
        public SortePerGame Game
        {
            get { return game; }
            set 
            {
                if (game == value)
                    return;

                game = value;
                OnPropertyChanged();
            }
        }

        private SortePerGame game;
        private Player opponentPlayer;
        private Player currentPlayer;
        private bool canPlayerDrawCard;

        /// <summary>
        /// The current pairs which has to be checked
        /// </summary>
        private List<ImageEventArgs> upheldCards;

        public SortePerGameViewModel()
        {
            Game = new SortePerGame();
            upheldCards = new List<ImageEventArgs>();
        }

        /// <summary>
        /// Initialise all the game values
        /// </summary>
        public void InitGame()
        {
            Game.Start();

            CanPlayerDrawCard = true;
            CurrentPlayer = Game.CurrentPlayer;
            OpponentPlayer = Game.OpponentPlayer;
        }

        /// <summary>
        /// Change the turn and update ui
        /// </summary>
        private void ChangeTurns()
        {
            Game.ChangeTurn();
            CanPlayerDrawCard = true;
            upheldCards.Clear();
            CurrentPlayer = Game.CurrentPlayer;
            OpponentPlayer = Game.OpponentPlayer;
        }


        /// <summary>
        /// Adds cards to the current pair that will be checked if match
        /// </summary>
        /// <param name="args"></param>
        private void AddCardToPairs(ImageEventArgs args)
        {
            if (!upheldCards.Exists((x) => x.Position == args.Position) && upheldCards.Count != 2)
                upheldCards.Add(args);
        }

        /// <summary>
        /// Returns whether the current pair is a match
        /// </summary>
        /// <returns></returns>
        private bool IsPairAnMatch()
        {
            Card c1 = CurrentPlayer.Hand[upheldCards[0].Position];
            Card c2 = CurrentPlayer.Hand[upheldCards[1].Position];

            return Game.IsCardsPair(c1, c2);
        }

        /// <summary>
        /// Removes the current pair from the hand
        /// </summary>
        private void RemoveCurrentPair()
        {
            Card c1 = CurrentPlayer.Hand[upheldCards[0].Position];
            Card c2 = CurrentPlayer.Hand[upheldCards[1].Position];

            CurrentPlayer.RemoveCardFromHand(c1);
            CurrentPlayer.RemoveCardFromHand(c2);

            upheldCards.Clear();
        }

        /// <summary>
        /// Called when the pairs is not a match
        /// Clears the current upheld cards and normalise cards position
        /// </summary>
        private void NormaliseNotPairs()
        {
            for (int i = 0; i < upheldCards.Count; i++)
            {
                Canvas.SetBottom(upheldCards[i].Image, 0);
                Canvas.SetZIndex(upheldCards[i].Image, 0);
            }

            upheldCards.Clear();
        }

    }
}
