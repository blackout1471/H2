using SortePerWpf.Model;
using SortePerWpf.Model.Players;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortePerWpf.ViewModel
{
    public class SortePerGameSettingsViewModel : BaseViewModel
    {
        /// <summary>
        /// adds a player to the players 
        /// </summary>
        public ICommand AddPlayerCommand => new RelayCommand((o) => AddPlayer(TextBoxString));

        /// <summary>
        /// The command for removing the current selected player
        /// </summary>
        public ICommand RemoveSelectedPlayerCommand => new RelayCommand((o) => RemoveSelectedPlayer());

        public ICommand StartSortePerGame => new RelayCommand((o) => StartSortePerGameNavigator());

        /// <summary>
        /// The players for the game
        /// </summary>
        public ObservableCollection<Player> Players
        {
            get { return players; }
            set { players = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// The textboxs text
        /// </summary>
        public string TextBoxString
        {
            get
            {
                return textBoxString;
            }

            set
            {
                textBoxString = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The current selected player in listbox
        /// </summary>
        public Player SelectedPlayer
        {
            get
            {
                return selectedPlayer;
            }

            set
            {
                selectedPlayer = value;
                OnPropertyChanged();
            }
        }

        private string textBoxString;
        private Player selectedPlayer;
        private ObservableCollection<Player> players;

        public SortePerGameSettingsViewModel()
        {
            Players = new ObservableCollection<Player>();
        }

        /// <summary>
        /// Adds a player to the list and displays
        /// </summary>
        /// <param name="name"></param>
        private void AddPlayer(string name)
        {
            Players.Add(new Player(name));
        }

        /// <summary>
        /// Removes the selected player from the players list
        /// </summary>
        private void RemoveSelectedPlayer()
        {
            Players.Remove(SelectedPlayer);
            SelectedPlayer = null;
        }

        /// <summary>
        /// Starts the sorte per game
        /// </summary>
        private void StartSortePerGameNavigator()
        {
            SortePerGameViewModel gameVM = new SortePerGameViewModel();
            gameVM.Game.SetPlayers(Players.ToList());
            gameVM.InitGame();
            NavigationController.Instance.CurrentView = gameVM;
        }

    }
}
