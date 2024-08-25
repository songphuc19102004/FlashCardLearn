using FlashCardLearn.Commands;
using FlashCardLearn.Services;
using FlashCardLearn.Stores;
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
    public class HomeViewModel : ViewModelBase
    {
        private ICommand _createFlashCardSetCommand;
        private ObservableCollection<FlashCardSet> _flashCardSets;
        private ObservableCollection<FlashCardSet> _filteredFlashCardSets;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        private string _searchText;
        

        public HomeViewModel(NavigationStore navigationStore)
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
            OpenFlashCardSetCommand = new OpenFlashCardCommand(this, navigationStore);
            OpenSettingCommand = new NavigateCommand(new NavigationService(navigationStore, () => new SettingViewModel()));
            CreateFlashCardSetCommand = new NavigateCommand(new NavigationService(navigationStore, () => new FlashCardManagerViewModel(new FlashCardSet()
            {
                Title = "Enter your set name",
                Description = "Enter your description"
            }, true, navigationStore)));
            InitializeAsync();
        }

        public ICommand CreateFlashCardSetCommand { get; }
        public ICommand OpenSettingCommand { get; }
        public ICommand OpenFlashCardSetCommand { get; }

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

        private FlashCardSet _selectedFlashCardSet;

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
    }
}
