using FlashCardLearn.Commands;
using FlashCardLearn.Services;
using FlashCardLearn.Stores;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        private Settings _settings;
        private string _finishingSoundFileName;
        public SettingViewModel(NavigationStore navigationStore) 
        {
            _settings = SettingService.LoadSettings();
            _finishingSoundFileName = Path.GetFileName(_settings.FinishingSoundFilePath);
            ChangeFinishingSoundCommand = new ChangeFinishingSoundCommand(this);
            BackToHomeCommand = new NavigateCommand(new NavigationService(navigationStore, () => new HomeViewModel(navigationStore)));
        }

        public string FinishingSoundFilePath
        {
            get => _settings.FinishingSoundFilePath;
            set
            {
                _settings.FinishingSoundFilePath = value;
                OnPropertyChanged();
                SettingService.SaveSettings(_settings);
                FinishingSoundFileName = Path.GetFileName(_settings.FinishingSoundFilePath);
            }
        }

        public string FinishingSoundFileName
        {
            get => _finishingSoundFileName;
            set
            {
                _finishingSoundFileName = value;
                OnPropertyChanged();
            }
        }


        public ICommand ChangeFinishingSoundCommand { get; }
        public ICommand BackToHomeCommand { get; }
    }
}
