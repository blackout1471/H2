﻿using System;
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
			CurrentView = new SortePerGameViewModel();
		}

		public BaseViewModel CurrentView
		{
			get { return currentView; }
			set 
			{
				if (value != currentView)
					OnPropertyChanged();

				currentView = value; 
			}
		}
		private BaseViewModel currentView;

	}
}