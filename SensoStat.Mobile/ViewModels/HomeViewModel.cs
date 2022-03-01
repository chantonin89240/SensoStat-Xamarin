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
        }
        #endregion
        #region Lifecycle

        #endregion
        #region Privates

        #endregion
        #region Publics

        #endregion
        #region Commands
        public DelegateCommand NextCommand { get; set; }

        private async Task DoNextCommand()
        {
            
            if (Index < 1) // && !Intructions[Index+1].IsQuestion
            {
                Index++;
                Instruction = GetInstruction();
            }
            else
            {
                Index++;
                await NavigationService.NavigateAsync(Constants.Answer);
            }
        }
        #endregion
        #region Methods
        
        #endregion
    }
}

