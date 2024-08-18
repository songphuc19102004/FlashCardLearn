using FlashCardLearn.Interfaces;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FlashCardLearn.ViewModel
{
    public class LearnViewModel : INotifyPropertyChanged, ICloseWindows
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private FlashCardSet _currentFlashCardSet;
        private ObservableCollection<FlashCard> _currentFlashCards;
        private FlashCard _shownFlashCard;
        private ICommand _forwardCommand;
        private ICommand _backCommand;
        private ICommand _flipCommand;
        private bool _isQuestionVisible = true;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        public Action Close { get; set; }

        public LearnViewModel() 
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
        }
        
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

        public ICommand ForwardCommand
        {
            get
            {
                if(_forwardCommand == null)
                {
                    _forwardCommand = new RelayCommand(Forward, CanForward);
                }
                return _forwardCommand;
            }
        }

        private bool CanForward(object obj)
        {
            return true;

        }

        private void Forward(object obj)
        {
            if(Progress < _currentFlashCards.Count - 1)
            {
                Progress++;
                ShownFlashCard = _currentFlashCards[Progress.Value];
            }
            else
            {
                MessageBox.Show("Congratulations!, You have finished this flash card set!", "Congrats", MessageBoxButton.OK);
            }
            IsQuestionVisible = true;
        }

        public ICommand BackCommand
        {
            get
            {
                if(_backCommand == null)
                {
                    _backCommand = new RelayCommand(Back, CanBack);
                }
                return _backCommand;
            }
        }

        public bool CanBack(object obj)
        {
            if(Progress.Value == 0)
            {
                return false;
            }
            return true;
        }

        public void Back(object obj)
        {
            Progress--;
            ShownFlashCard = _currentFlashCards[Progress.Value];
            IsQuestionVisible = true;
        }

        public ICommand FlipCommand 
        {
            get
            {
                if(_flipCommand == null)
                {
                    _flipCommand = new RelayCommand(Flip, CanFlip);
                }
                return _flipCommand;
            }

        }

        private bool CanFlip(object obj)
        {
            return true;
        }

        private void Flip(object obj)
        {
            IsQuestionVisible = !IsQuestionVisible;
        }

        public bool CanClose()
        {
            //Update progress when close
            _flashCardSetService.UpdateAsync(_currentFlashCardSet);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
