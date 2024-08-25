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
        private ICommand _forwardCommand;
        private ICommand _backCommand;
        private ICommand _flipCommand;
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
            BackToFlashCardManagerView = new NavigateCommand(new NavigationService(navigationStore, () => new FlashCardManagerViewModel(selectedFlashCardSet, false, navigationStore)));
            ForwardCommand = new ForwardCommand(this);
            BackCommand = new BackCommand(this);
        }
        
        public ICommand BackToFlashCardManagerView { get; }

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


        private void Forward(object obj)
        {
            if(Progress < _currentFlashCards.Count - 1)
            {
                Progress++;
                ShownFlashCard = _currentFlashCards[Progress.Value];
            }
            else
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Phuc\Desktop\repo2\FlashCardLearn\FlashCardLearn\Resources\Sounds\children_yay.wav");
                soundPlayer.Play();
                MessageBox.Show("Congratulations!, You have finished this flash card set!", "Congrats", MessageBoxButton.OK);
            }
            IsQuestionVisible = true;
        }

        public ICommand BackCommand { get; }


        public ICommand FlipCommand;

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
    }
}
