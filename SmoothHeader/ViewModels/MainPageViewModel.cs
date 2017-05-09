using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace SmoothHeader.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		public string Title { get; set; }

		public string PlayerImage { get; set; }

		public string PlayerName { get; set; }

		public MainPageViewModel()
		{

		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			Title = "Smooth Header";

			PlayerImage = "http://www.forums.nba-live.com/dl_mod/thumbs/3638_MIA_James_LeBron.png";

			PlayerName = "Serge Ibanka";
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			
		}
	}
}
