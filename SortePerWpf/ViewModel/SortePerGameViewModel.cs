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
        /// <summary>
        /// The command for when hovering a card
        /// </summary>
        public ICommand HoverCardCommand => new RelayCommand((o) => HoverCardEvent((ImageEventArgs)o));

        /// <summary>
        /// The command for when leaving a hovered card
        /// </summary>
        public ICommand UnHoverCardCommand => new RelayCommand((o) => UnHoverCardEvent((ImageEventArgs)o));

        /// <summary>
        /// The command for when clicking a card on the opponent
        /// </summary>
        public ICommand ClickOnOpponentCardCommand => new RelayCommand((o) => ClickCardFromOpponentEvent((ImageEventArgs)o));

        /// <summary>
        /// The command for when the current player clicks it's own cards
        /// </summary>
        public ICommand ClickOnCurrentCardCommand => new RelayCommand((o) => ClickCardCurrentEvent((ImageEventArgs)o));

        /// <summary>
        /// The current player
        /// </summary>
        public Player CurrentPlayer => Game.CurrentPlayer;

        /// <summary>
        /// The current game which is going happening
        /// </summary>
        public SortePerGame Game
        {
            get { return game; }
            private set { game = value; }
        }

        private SortePerGame game;
        ImageEventArgs lastClickedCard; // The current upheld card by the current player

        public SortePerGameViewModel()
        {
            Game = new SortePerGame();

            Game.AddNewPlayer(new Player("Emil"));
            Game.AddNewPlayer(new Player("Hubba"));
            Game.Start();
        }

        /// <summary>
        /// Sets the position and the z index for the image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="posFromBot"></param>
        /// <param name="zIndex"></param>
        private void SetImagePosition(Image image, int posFromBot, int zIndex)
        {
            Canvas.SetBottom(image, posFromBot);
            Canvas.SetZIndex(image, zIndex);
        }

        #region Events

        /// <summary>
        /// Method for when hovering a card
        /// </summary>
        /// <param name="image"></param>
        private void HoverCardEvent(ImageEventArgs args)
        {
            if (lastClickedCard != null)
                if (args.Image == lastClickedCard.Image)
                    return;

            SetImagePosition(args.Image, 20, 1);
        }

        /// <summary>
        /// Method for when leaving a card
        /// </summary>
        /// <param name="image"></param>
        private void UnHoverCardEvent(ImageEventArgs args)
        {
            if (lastClickedCard != null)
                if (args.Image == lastClickedCard.Image)
                    return;

            SetImagePosition(args.Image, 0, 0);
        }

        /// <summary>
        /// Method for when clicking on opponents cards
        /// </summary>
        /// <param name="image"></param>
        private void ClickCardFromOpponentEvent(ImageEventArgs args)
        {
            Game.DrawFromOpponent(args.Position);
            OnPropertyChanged(null);
        }

        /// <summary>
        /// Method for when current player is clicking
        /// </summary>
        /// <param name="args"></param>
        /// TODO: Make this method smaller
        private void ClickCardCurrentEvent(ImageEventArgs args)
        {
            if (lastClickedCard != null)
            {
                if (lastClickedCard.Position == args.Position)
                    return;

                Card c1 = CurrentPlayer.Hand[lastClickedCard.Position];
                Card c2 = CurrentPlayer.Hand[args.Position];

                if (Game.IsCardsPair(c1, c2))
                {
                    CurrentPlayer.RemoveCardFromHand(c1);
                    CurrentPlayer.RemoveCardFromHand(c2);
                    OnPropertyChanged(null);
                }
                lastClickedCard = null;
            }
            else
                lastClickedCard = args;

            SetImagePosition(args.Image, 20, 0);
        }

        #endregion


    }
}
