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
        private ICommand _createFlashCardSetCommand;
        private ObservableCollection<FlashCardSet> _flashCardSets;
        private ObservableCollection<FlashCardSet> _filteredFlashCardSets;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        private string _searchText;

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
            _flashCardSets = new ObservableCollection<FlashCardSet>(flashCardSets);
            FilteredFlashCardSets = _flashCardSets; 
        }

        public string SearchText 
        {
            get => _searchText;
            set
            {
                if(_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FilterFlashCardSets();
                }
            }
        }

        public ObservableCollection<FlashCardSet> FilteredFlashCardSets
        {
            get
            {
                return _filteredFlashCardSets;
            }
            set
            {
                _filteredFlashCardSets = value;
                OnPropertyChanged();
            }
        }

        private void FilterFlashCardSets()
        {
            if(string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredFlashCardSets = new ObservableCollection<FlashCardSet>(_flashCardSets);
            }
            else
            {
                FilteredFlashCardSets = new ObservableCollection<FlashCardSet>(
                    _flashCardSets.Where(set => set.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                );
            }
        }

        #region Open
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

            var viewModel = new FlashCardManagerViewModel();
            viewModel.SelectedFlashCardSet = flashCardSet;
            
            FlashCardManagerView managerView = new FlashCardManagerView();
            managerView.DataContext = viewModel;
            managerView.ShowDialog();
        }
        #endregion
        #region Create
        public ICommand CreateCommand
        {
            get
            {
                if(_createFlashCardSetCommand == null)
                {
                    _createFlashCardSetCommand = new RelayCommand(Create, CanCreate);
                }
                return _createFlashCardSetCommand;
            }
        }

        private bool CanCreate(object obj)
        {
            return true;
        }

        private void Create(object obj) 
        {
            FlashCardManagerViewModel flashCardManagerViewModel = new FlashCardManagerViewModel();
            flashCardManagerViewModel.IsCreateWindow = true;

            FlashCardManagerView view = new FlashCardManagerView();
            view.DataContext = flashCardManagerViewModel;
            view.ShowDialog();
        }

        #endregion

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
