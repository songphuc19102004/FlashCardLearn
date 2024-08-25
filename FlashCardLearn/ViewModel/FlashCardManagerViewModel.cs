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
using System.Windows.Controls;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class FlashCardManagerViewModel : ViewModelBase
    {
        private int _numberOfFlashCards;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        private bool _isCreate;
        public ICommand ExportFlashCardCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand LearnCommand { get; }
        public ICommand AutoSaveCommand { get; }
        public ICommand OpenFlashCardCommand { get; }
        public Action Close { get; set; }

        public FlashCardManagerViewModel(FlashCardSet selectedFlashCardSet, bool IsCreate, NavigationStore navigationStore)
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
            _selectedFlashCardSet = selectedFlashCardSet;
            SelectedFlashCardSet = _selectedFlashCardSet;
            _isCreate = IsCreate;
            ExportFlashCardCommand = new ExportFlashCardCommand(this);
            LearnCommand = new LearnCommand(navigationStore, this);
            BackToHomeViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new HomeViewModel(navigationStore)));
            CreateCommand = new CreateCommand(navigationStore, this);
            AutoSaveCommand = new AutoSaveCommand();
            OpenFlashCardCommand = new OpenCreateFlashCardViewCommand(navigationStore, selectedFlashCardSet);
        }

        public ICommand BackToHomeViewCommand { get; }

        private FlashCardSet _selectedFlashCardSet;
        public FlashCardSet SelectedFlashCardSet
        {
            get => _selectedFlashCardSet;
            set
            {
                _selectedFlashCardSet = value;
                OnPropertyChanged();
                InitializeFlashCards();
            }
        }

        public String Title
        {
            get => _selectedFlashCardSet.Title;
            set
            {
                _selectedFlashCardSet.Title = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<FlashCard> _flashCards;
        public ObservableCollection<FlashCard> FlashCards
        {
            get => _flashCards;
            set
            {
                _flashCards = value;
                OnPropertyChanged();
            }
        }

        public bool IsCreate
        {
            get => _isCreate;
            set
            {
                _isCreate = value;
                OnPropertyChanged();
            }
        }

        public bool IsLearn
        {
            get => !_isCreate;
        }

        private void InitializeFlashCards()
        {
            if(_selectedFlashCardSet != null)
            {
                _flashCards = new ObservableCollection<FlashCard>(_flashCardService.GetFlashCardsBySetId(_selectedFlashCardSet.Id));
            }
        }
    }
}
