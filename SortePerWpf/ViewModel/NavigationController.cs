using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf.ViewModel
{
    public class NavigationController : BaseViewModel
    {
		// Singleton Pattern
		private static NavigationController instance;

		public static NavigationController Instance
		{
			get 
			{
				if (instance == null)
					instance = new NavigationController();

				return instance;
			}
		}

		private NavigationController() 
		{
			CurrentView = new SortePerGameSettingsViewModel();
		}

		/// <summary>
		/// The current view in the application
		/// </summary>
		public BaseViewModel CurrentView
		{
			get { return currentView; }
			set 
			{
				currentView = value;
				OnPropertyChanged();
			}
		}
		private BaseViewModel currentView;

	}
}
