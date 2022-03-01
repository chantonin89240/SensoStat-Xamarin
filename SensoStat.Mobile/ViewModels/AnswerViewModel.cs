using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        #region CTOR
        public AnswerViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            GoAnswerCommand = new DelegateCommand(async () => await DoGoAnswerCommand());

            GoSpeechCommand = new DelegateCommand(async () => await DoGoSpeechCommand());
        }

        #endregion
        #region Lifecycle
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ActiveBool = false;

            _speechConfig = SpeechConfig.FromSubscription(Constants.CognitiveServicesApiKey, Constants.CognitiveServicesRegion);

            base.OnNavigatedTo(parameters);
        }

 
        #endregion
        #region Privates

        #endregion
        #region Publics

        #endregion
        #region Commands
        public DelegateCommand GoAnswerCommand { get; set; }

        private async Task DoGoAnswerCommand()
        {
            await NavigationService.NavigateAsync(Constants.AnswerPage);
        }

        public DelegateCommand GoSpeechCommand { get; set; }

        private async Task DoGoSpeechCommand()
        {
            await NavigationService.NavigateAsync(Constants.TextToSpeech);
        }
        #endregion
        #region Methods

        #endregion
    }
}
