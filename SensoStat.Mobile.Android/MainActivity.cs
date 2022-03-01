using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using SensoStat.Mobile.Droid.Services;
using SensoStat.Mobile.Repositories.Interface;
using SensoStat.Mobile.Repositories;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.Mobile.Droid
{
    [Activity(Label = "SensoStat.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        IMicrophoneService micService;
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            base.OnCreate(savedInstanceState);

            //micService = DependencyService.Resolve<IMicrophoneService>();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new AndroidInitializer()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            switch (requestCode)
            {
                case AndroidMicrophoneServices.RecordAudioPermissionCode:
                    if (grantResults[0] == Permission.Granted)
                    {
                        micService.OnRequestPermissionResult(true);
                    }
                    else
                    {
                        micService.OnRequestPermissionResult(false);
                    }
                    break;
            }
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDatabase, SqliteConnectionService>();
            containerRegistry.Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
