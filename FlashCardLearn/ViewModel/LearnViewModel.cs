using FlashCardLearn.Commands;
using FlashCardLearn.Interfaces;
using FlashCardLearn.Services;
using FlashCardLearn.Stores;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class LearnViewModel : ViewModelBase, ICloseWindows
    {
        private FlashCardSet _currentFlashCardSet;
        private ObservableCollection<FlashCard> _currentFlashCards;
        private FlashCard _shownFlashCard;
        private bool _isQuestionVisible = true;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        public Action Close { get; set; }

        public LearnViewModel(FlashCardSet selectedFlashCardSet, NavigationStore navigationStore) 
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
            _currentFlashCardSet = selectedFlashCardSet;
            CurrentFlashCardSet = _currentFlashCardSet;
            ForwardCommand = new ForwardCommand(this);
            BackCommand = new BackCommand(this);
            FlipCardCommand = new FlipCardCommand(this);
            BackAndSaveProgressCommand = new BackAndSaveProgressCommand(navigationStore);
        }
        
        public ICommand BackAndSaveProgressCommand { get; }

        public FlashCardSet CurrentFlashCardSet
        {
            get => _currentFlashCardSet;
            set
            {
                _currentFlashCardSet = value;
                OnPropertyChanged();
                InitializeFlashCards();

            }
        }

        public ObservableCollection<FlashCard> CurrentFlashCards
        {
            get => _currentFlashCards;
            set
            {
                _currentFlashCards = value;
                OnPropertyChanged();
            }
        }

        public int? Progress
        {
            get => _currentFlashCardSet.Progress;
            set
            {
                _currentFlashCardSet.Progress = value;
                OnPropertyChanged();
            }
        }

        private void InitializeFlashCards()
        {
            if(_currentFlashCardSet != null)
            {
                _currentFlashCards = new ObservableCollection<FlashCard>(_flashCardService.GetFlashCardsBySetId(_currentFlashCardSet.Id));
                Progress = _currentFlashCardSet.Progress;
                if(_currentFlashCards.Any())
                {
                    ShownFlashCard = _currentFlashCards[Progress.Value];
                }
                OnPropertyChanged(nameof(CurrentFlashCards));
                OnPropertyChanged(nameof(OverallProgress));
            }
        }

        public int OverallProgress
        {
            get => _currentFlashCards.Count - 1;
        }

        public FlashCard ShownFlashCard
        {
            get => _currentFlashCards[Progress.Value];
            set
            {
                _shownFlashCard = value;
                OnPropertyChanged();
            }
        }

        public bool IsQuestionVisible
        {
            get => _isQuestionVisible;
            set
            {
                _isQuestionVisible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAnswerVisible));
            }
        }

        public bool IsAnswerVisible => !IsQuestionVisible;

        public ICommand ForwardCommand { get; }

        public ICommand BackCommand { get; }

        public ICommand FlipCardCommand { get; }

        public bool CanClose()
        {
            //Update progress when close
            _flashCardSetService.UpdateAsync(_currentFlashCardSet);
            return true;
        }
    }
}
