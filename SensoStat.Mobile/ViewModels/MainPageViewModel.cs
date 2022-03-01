using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Models.Entities;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region CTOR
        public MainPageViewModel(IAlertdialogService alertdialogService, INavigationService navigationService,
            IDatabaseService databaseService, IRequestService requestService) : base(alertdialogService, navigationService)
        {
            _requestService = requestService;
            _databaseService = databaseService;

            StartCommand = new DelegateCommand(async () => await DoStartCommand());

           
        }

        #endregion
        #region Lifecycle
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters?.Any() ?? false)
            {
                // var instructions = parameters.GetValue<List<InstructionEntity>>("instructions");
                // Instructions = instructions;
            }
            else
            {
                //No parameter 
                // await NavigationService.GoBackAsync();
            }

            await GetSession();

            base.OnNavigatedTo(parameters);
        }
        #endregion

        #region Privates
        private readonly IDatabaseService _databaseService;
        private readonly IRequestService _requestService;
        #endregion

        #region Public

        // Public attribut
        #region MsgAccueil =>  string
        private string _msgAccueil;

        public string MsgAccueil
        {
            get => _msgAccueil;
            set => SetProperty(ref _msgAccueil, value);
        }
        #endregion
        #endregion

        #region Commands
        public DelegateCommand StartCommand { get; set; }

        private async Task DoStartCommand()
        {
            await NavigationService.NavigateAsync(Constants.HomeSession);
        }
        #endregion
        

        #region Methods
        private async Task GetSession()
        {
            try
            {
                var session = await _requestService.GetSession();

                if (session != null)
                {
                    Session = new SessionEntity(session);
                    session.Instructions.ForEach(i => Instructions.Add(new InstructionEntity(i)));
                    session.Presentations.ForEach(p => Presentations.Add(new PresentationEntity(p)));

                    var test = Instructions;

                    MsgAccueil = GetMsgAccueil();
                    Title = GetMsgAccueil();
                    Instruction = GetInstruction();
                    Product = GetProduct();

                    SaveSession();
                }
                else
                {
                    //Display error
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Display error
            }
        }

        private async Task SaveSession()
        {
            try
            {
                if (Session == null)
                {
                    return;
                }

                var result = _databaseService.InsertSession(Session);
                Instructions.ForEach(i => _databaseService.InsertInstruction(i));
                Presentations.ForEach(p => _databaseService.InsertPresentation(p));

                if (result != null)
                {
                    //display success
                }
                else
                {
                    //display error
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //display error
            }
        }
        #endregion
    }
}