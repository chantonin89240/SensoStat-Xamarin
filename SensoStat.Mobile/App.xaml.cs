using System;
using Prism;
using Prism.Ioc;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Helpers;
using SensoStat.Mobile.Helpers.Interface;
using SensoStat.Mobile.Services;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.Mobile.ViewModels;
using SensoStat.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SensoStat.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{Constants.NavigationPage}/{Constants.MainPage}");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterHelpers(containerRegistry);
            RegisterRepositories(containerRegistry);
            RegisterServices(containerRegistry);
            RegisterViews(containerRegistry);
        }

        private void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.NavigationPage);
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(Constants.MainPage);
            containerRegistry.RegisterForNavigation<HomeSession, HomeViewModel>(Constants.HomeSession);
            containerRegistry.RegisterForNavigation<Answer, AnswerViewModel>(Constants.Answer);
            containerRegistry.RegisterForNavigation<AnswerPage, AnswerPageViewModel>(Constants.AnswerPage);
            containerRegistry.RegisterForNavigation<FinalPage, FinalPageViewModel>(Constants.FinalPage);
            containerRegistry.RegisterForNavigation<TextToSpeech, TextToSpeechViewModel>(Constants.TextToSpeech);
        }

        private void RegisterRepositories(IContainerRegistry containerRegistry)
        {

        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAlertdialogService, AlertDialogService>();
            containerRegistry.RegisterSingleton<IRequestService, RequestService>();
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
        }

        private void RegisterHelpers(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDataTransferHelper, DataTransferHelper>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}