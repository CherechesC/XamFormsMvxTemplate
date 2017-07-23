using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.ViewModels
{
    public class SecondViewModel : MvxViewModel<Dictionary<string, string>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly Services.IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;

        private Dictionary<string, string> _parameter;

        public SecondViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _settings = settings;
            _userDialogs = userDialogs;

            MainPageButtonText = "test";
        }

        public string MainPageButtonText { get; set; }

        public IMvxAsyncCommand BackCommand => new MvxAsyncCommand(async () =>
        {
            _userDialogs.Alert("Bye bye");
            await _navigationService.Close(this);
        });

        public override Task Initialize(Dictionary<string, string> parameter)
        {
            _parameter = parameter;

            if (_parameter != null && _parameter.ContainsKey("ButtonText"))
                MainPageButtonText = "ButtonText";

            return Task.FromResult(true);
        }

        public int SuperNumber
        {
            get { return _settings.SuperNumber; }
            set { _settings.SuperNumber = value; }
        }
    }
}