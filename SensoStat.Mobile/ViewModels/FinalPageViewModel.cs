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

            MsgFinal = GetMsgFinal();
        }
        #endregion
        #region Lifecycle
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await SpeechUp(MsgFinal);
        }
        #endregion
        #region Privates

        #endregion
        #region Publics
        #region MsgFinal =>  string
        private string _msgFinal;

        public string MsgFinal
        {
            get => _msgFinal;
            set => SetProperty(ref _msgFinal, value);
        }
        #endregion
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
