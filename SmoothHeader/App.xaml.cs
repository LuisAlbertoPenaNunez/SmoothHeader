using Prism.Unity;
using SmoothHeader.Views;
using Xamarin.Forms;

namespace SmoothHeader
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync($"SmoothHeaderNavigationPage/MainPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<SmoothHeaderNavigationPage>();
			Container.RegisterTypeForNavigation<MainPage>();
		}
	}
}
