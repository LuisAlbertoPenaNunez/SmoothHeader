using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using SmoothHeader.Views.Views;

namespace SmoothHeader.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		public string Title { get; set; }

		public string PlayerImage { get; set; }

		public string PlayerName { get; set; }

		public ICommand ScreenIsScrollingCommand { get; set; }

		public double ScreenPosition { get; set; }

        public IList<string> PlayerData { get; set; }

		public MainPageViewModel()
		{
			ScreenIsScrollingCommand = new Command<double>(OnScreenIsScrolling);
		}

		void OnScreenIsScrolling(double position)
		{
			ScreenPosition = position;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Smooth Header";

            PlayerImage = "http://www.forums.nba-live.com/dl_mod/thumbs/3638_MIA_James_LeBron.png";

            PlayerName = "Serge Ibanka";

            PlayerData = new List<string>
            {
                "Born",
                "12/09/2001",
                "Age",
                "25",
                "From",
                "Draft",
                "Nba Debut",
                "2014"
            };
        }

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			
		}
	}
}
