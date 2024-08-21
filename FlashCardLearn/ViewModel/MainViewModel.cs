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
                    _openFlashCardSetCommand = new RelayCommand(OpenFlashCardSet, CanOpenFlashCardSets);
                }
                return _openFlashCardSetCommand;
            }
        }

        private bool CanOpenFlashCardSets(object obj)
        {
            return true;
        }

        private async void OpenFlashCardSet(object obj)
        {
            // Implement the logic to open the selected flashcard set
            // TODO: If there are no flash cards in the set, redirect
            // ask user to add flash card to FlashCardManagerView
            var flashCardSet = obj as FlashCardSet;

            if(flashCardSet == null)
            {
                return;
            }

            //if(await _flashCardSetService.GetFlashCardCountForSetAsync(flashCardSet.Id) == 0)
            //{
            //    MessageBox.Show("What the fuck bro? There is nothing here");
            //    return;
            //}

            var viewModel = new FlashCardManagerViewModel();
            viewModel.SelectedFlashCardSet = flashCardSet;
            
            FlashCardManagerView managerView = new FlashCardManagerView();
            managerView.DataContext = viewModel;
            managerView.ShowDialog();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
