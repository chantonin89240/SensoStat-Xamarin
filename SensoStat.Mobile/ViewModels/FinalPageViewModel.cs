using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class FinalPageViewModel : BaseViewModel
    {
        #region CTOR
        public FinalPageViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            CloseCommand = new DelegateCommand(() => DoCloseCommand());

            Title = "Bienvenue sur votre séance sensorielle SensoStat!";
        }
        #endregion
        #region Lifecycle

        #endregion
        #region Privates

        #endregion
        #region Publics

        #endregion
        #region Commands
        public DelegateCommand CloseCommand { get; set; }

        private void DoCloseCommand()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        #endregion
        #region Methods

        #endregion
    }
}
