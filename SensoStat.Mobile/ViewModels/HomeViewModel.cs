 using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region CTOR
        public HomeViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            NextCommand = new DelegateCommand(async () => await DoNextCommand());
            Instruction = GetInstruction();
            Product = GetProduct();
        }
        #endregion
        #region Lifecycle
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {

            await SpeechUp(Instruction);

            base.OnNavigatedTo(parameters);
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
            if (Index < Instructions.Count-1 && !Instructions[Index+1].IsQuestion)
            {
                Index++;
                Instruction = GetInstruction();
                await SpeechUp(Instruction);
            }
            else if (Index < Instructions.Count - 1)
            {
                Index++;
                await NavigationService.NavigateAsync(Constants.Answer);
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

