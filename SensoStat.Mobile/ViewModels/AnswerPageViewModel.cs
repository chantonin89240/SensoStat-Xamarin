using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;
using Xamarin.Forms;

namespace SensoStat.Mobile.ViewModels
{
    public class AnswerPageViewModel : BaseViewModel
    {

        #region CTOR
        public AnswerPageViewModel(IAlertdialogService alertdialogService, INavigationService navigationService, IRequestService requestService) : base(alertdialogService, navigationService)
        {
            //micService = DependencyService.Resolve<IMicrophoneService>();

            NextCommand = new DelegateCommand(async () => await DoNextCommand());
            CleanEditorCommand = new DelegateCommand(async () => await DoCleanEditorCommand());
            TranscribeCommand = new DelegateCommand(async () => await DoTranscribeCommand());

            micService = DependencyService.Resolve<IMicrophoneService>();
            _requestService = requestService;
        }

        #endregion
            #region Lifecycle
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await SpeechUp("C'est à vous");
        }


        #endregion
        #region Privates
        private IRequestService _requestService;
        #endregion
        #region Publics
        SpeechRecognizer recognizer;
        IMicrophoneService micService;
        bool isTranscribing = false;


        #region IsRunning =>  string
        private bool _isRunning;

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        #endregion

        #region TextButton =>  string
        private string _textButton = "Répondre";

        public string TextButton
        {
            get => _textButton;
            set => SetProperty(ref _textButton, value);
        }
        #endregion

        #region TextEditor =>  string
        private string _textEditor;

        public string TextEditor
        {
            get => _textEditor;
            set => SetProperty(ref _textEditor, value);
        }
        #endregion

        #endregion
        #region Commands
        public DelegateCommand NextCommand { get; set; }

        private async Task DoNextCommand()
        {
            var response =this.TextEditor;
            var idPaneliste = this.Session.IdPanelist;
            var idInstruction = this.Instructions[Index].Id;
            var idproduit = this.Presentations[IndexProduct].IdProduct;

            ResponseDownDto responseDto = new ResponseDownDto()
            {
                IdInstruction = idInstruction,
                IdProduct = idproduit,
                IdPaneliste = idPaneliste,
                CommentResponse = response,
                Token = "a",
            };

            await _requestService.PostReponse(responseDto);

            if (Index < Instructions.Count-1 && !Instructions[Index+1].IsQuestion)
            {
                Index++;
                await NavigationService.NavigateAsync(Constants.HomeSession);
            }
            else if (Index < Instructions.Count - 1)
            {
                Index++;
                await NavigationService.NavigateAsync(Constants.Answer);
            }
            else if (IndexProduct < Presentations.Count-1)
            {
                Index = 0;
                IndexProduct++;
                await NavigationService.NavigateAsync(Constants.HomeSession);
            }
            else
            {
                await NavigationService.NavigateAsync(Constants.FinalPage);
            }
        }

        public DelegateCommand CleanEditorCommand { get; set; }

        private async Task DoCleanEditorCommand()
        {
            TextEditor = string.Empty;
        }

        public DelegateCommand TranscribeCommand { get; set; }

        public async Task DoTranscribeCommand()
        {
            bool isMicEnabled = true; //await micService.GetPermissionAsync();

            // EARLY OUT: make sure mic is accessible
            if (!isMicEnabled)
            {
                UpdateTranscription("Please grant access to the microphone!");
                return;
            }

            // initialize speech recognizer 
            if (recognizer == null)
            {
                var config = SpeechConfig.FromSubscription(Constants.CognitiveServicesApiKey, Constants.CognitiveServicesRegion);
                config.SpeechRecognitionLanguage = "fr-FR";
                recognizer = new SpeechRecognizer(config);
                recognizer.Recognized += (obj, args) =>
                {
                    UpdateTranscription(args.Result.Text);
                };
            }

            // if already transcribing, stop speech recognizer
            if (isTranscribing)
            {
                try
                {
                    await recognizer.StopContinuousRecognitionAsync();
                }
                catch (Exception ex)
                {
                    UpdateTranscription(ex.Message);
                }
                isTranscribing = false;
            }

            // if not transcribing, start speech recognizer
            else
            {
                try
                {
                    await recognizer.StartContinuousRecognitionAsync();
                }
                catch (Exception ex)
                {
                    UpdateTranscription(ex.Message);
                }
                isTranscribing = true;
            }
            UpdateDisplayState();
        }
        #endregion
        #region Methods



        public void UpdateTranscription(string newText)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (!string.IsNullOrWhiteSpace(newText))
                {
                    TextEditor += $"{newText}\n";
                }
            });
        }

        public void UpdateDisplayState()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (isTranscribing)
                {
                    TextButton = "Stop";
                    //transcribeButton.BackgroundColor = Color.Red;
                    IsRunning = true;
                }
                else
                {
                    TextButton = "Enregistrer";
                    //transcribeButton.BackgroundColor = Color.Green;
                    IsRunning = false;
                }
            });
        }


        #endregion
    }
}
