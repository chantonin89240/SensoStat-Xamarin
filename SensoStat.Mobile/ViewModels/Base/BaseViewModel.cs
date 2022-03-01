using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Models.Entities;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.ViewModels.Base
{
	public class BaseViewModel : BindableBase, INavigationAware, IPageLifecycleAware
	{
        #region CTOR
        public BaseViewModel(IAlertdialogService alertdialogService, INavigationService navigationService)
        {
            ReadCommand = new DelegateCommand(async () => await DoReadCommand());

            NavigationService = navigationService;
            AlertDialogService = alertdialogService;

            Instruction = GetInstruction();

            Product = GetProduct();
        }
        #endregion

        #region Lifecycle
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnAppearing()
        {

        }

        public void OnDisappearing()
        {

        }
        #endregion

        #region Privates
        public SpeechConfig _speechConfig;
        private SpeechSynthesizer _speechSynthesizer;
        #endregion

        #region Publics
        // Protected
        protected IAlertdialogService AlertDialogService;
        protected INavigationService NavigationService;

        // Public attribut
        #region  List<InstructionEntity> => Instructions

        private List<InstructionEntity> _instructionsr = new List<InstructionEntity>();

        public List<InstructionEntity> InstructionsR
        {
            get => _instructionsr;
            set => this.SetProperty(ref _instructionsr, value);
        }
        #endregion

        #region SessionEntity => Session

        private SessionEntity _Session;

        public SessionEntity Session
        {
            get => _Session;
            set => this.SetProperty(ref _Session, value);
        }
        #endregion

        #region SessionEntity => Session

        private List<PresentationEntity> _presentations = new List<PresentationEntity>();

        public List<PresentationEntity> Presentations
        {
            get => _presentations;
            set => this.SetProperty(ref _presentations, value);
        }
        #endregion
        #region Title =>  string
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion

        #region Instructions =>  List<string>
        private List<string> _instructions = new List<string>() { "Vous allez désormais tester le savon", "Savonnez vous les mains avec le savon", "Quels sont les points positifs du savon" };

        public List<string> Instructions
        {
            get => _instructions;
            set => SetProperty(ref _instructions, value);
        }
        #endregion

        #region Instruction =>  string
        private string _instruction;

        public string Instruction
        {
            get => _instruction;
            set => SetProperty(ref _instruction, value);
        }
        #endregion

        #region Products =>  List<string>
        private List<string> _products = new List<string>() { "n°763", "n°869" };

        public List<string> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }
        #endregion

        #region Product =>  string
        private string _product;

        public string Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }
        #endregion

        #region Index =>  integer
        private static int _index = 0;

        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }
        #endregion

        #region IndexProduct =>  integer
        private static int _indexProduct = 0;

        public int IndexProduct
        {
            get => _indexProduct;
            set => SetProperty(ref _indexProduct, value);
        }
        #endregion

        #region bool => IsBusy

        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }


        #endregion

        #region bool => ActiveBool
        private bool _activeBool;

        public bool ActiveBool
        {
            get => _activeBool;
            set => SetProperty(ref _activeBool, value);
        }
        #endregion

        #endregion

        #region Commands
        public DelegateCommand ReadCommand { get; set; }

        public async Task DoReadCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            await SpeechUp(Instruction);
            IsBusy = false;
        }
        #endregion

        #region Methods
        private async Task SpeechUp(string text)
        {
            ActiveBool = true;

            if (_speechSynthesizer == null)
            {
                _speechConfig.SpeechSynthesisLanguage = "fr-FR";
                _speechSynthesizer = new SpeechSynthesizer(_speechConfig);
            }

            await _speechSynthesizer.SpeakTextAsync(text);

            ActiveBool = false;
        }

        public string GetInstruction()
        {
            return InstructionsR[Index].Libelle;
        }

        public string GetProduct()
        {
            //var test = $"n°{Presentations[IndexProduct].CodeProduct}";
            return Products[IndexProduct];
        }

        public string GetMsgAccueil()
        {
            return Session.MsgAccueil;
        }

        public string GetMsgFinal()
        {
            return Session.MsgFinal;
        }
        #endregion 
    }
}

