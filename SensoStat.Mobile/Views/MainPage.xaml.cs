using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SensoStat.Mobile.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var safeInsets = On<iOS>().SafeAreaInsets();
        //    safeInsets.Left = 0;
        //    Padding = safeInsets;
        //}
    }
}
