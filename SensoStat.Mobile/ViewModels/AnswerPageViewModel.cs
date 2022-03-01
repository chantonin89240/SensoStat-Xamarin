using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;
using Xamarin.Forms;

namespace SensoStat.Mobile.ViewModels
{
    public class AnswerPageViewModel : BaseViewModel
    {
        


        #region CTOR
        public AnswerPageViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            //micService = DependencyService.Resolve<IMicrophoneService>();

            NextCommand = new DelegateCommand(async () => await DoNextCommand());
        }

        #endregion
        #region Lifecycle
        public override void OnNavigatedTo(INavigationParameters parameters)
        {

        }


        #endregion
        #region Privates

        #endregion
        #region Publics

        #endregion
        #region Commands
        public DelegateCommand NextCommand { get; set; }

        private async Task DoNextCommand()
        {

            if (Index < Instructions.Count-1) // && !Intructions[Index+1].IsQuestion
            {
                Index++;
                // si instruction et produit tatati tatata
                await NavigationService.NavigateAsync(Constants.HomeSession);
            }
            else
            {
                await NavigationService.NavigateAsync(Constants.FinalPage);
            }
        }
        #endregion
        #region Methods



        #endregion
    }
}
