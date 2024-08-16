using FlashCardLearn.Views;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ICommand _openFlashCardSetCommand;
        private ObservableCollection<FlashCardSet> _flashCardSets;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        public ObservableCollection<FlashCardSet> FlashCardSets
        {
            get => _flashCardSets;
            set
            {
                _flashCardSets = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadFlashCardSets();
        }

        private async Task LoadFlashCardSets()
        {
            var flashCardSets = await _flashCardSetService.GetFlashCardSetsAsync();
            Debug.WriteLine($"Loaded {flashCardSets.Count()} flash card sets");
            FlashCardSets = new ObservableCollection<FlashCardSet>(flashCardSets);
            Debug.WriteLine($"FlashCardSets property now has {FlashCardSets.Count} items");
        }

        public ICommand OpenFlashCardSetCommand
        {
            get
            {
                if(_openFlashCardSetCommand == null)
                {
                    _openFlashCardSetCommand = new RelayCommand<Window>(OpenFlashCardSet);
                }
                return _openFlashCardSetCommand;
            }
        }

        private void OpenFlashCardSet(object obj)
        {
            // Implement the logic to open the selected flashcard set
            // For example, you could navigate to a new view or open a dialog
            var mainWindow = obj as Window;
            LearnView learnView = new LearnView();
            learnView.Owner = mainWindow;
            learnView.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            learnView.Show();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
