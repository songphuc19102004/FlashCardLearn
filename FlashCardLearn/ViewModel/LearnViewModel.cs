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
    public class LearnViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private FlashCardSet _currentFlashCardSet;
        private ObservableCollection<FlashCard> _currentFlashCards;
        private FlashCard _shownFlashCard;
        private ICommand _forwardCommand;
        private ICommand _backCommand;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;

        public LearnViewModel(FlashCardSet flashCardSet) 
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
            _currentFlashCardSet = flashCardSet;
            _currentFlashCards = _flashCardService.GetFlashCardsBySetId(_currentFlashCardSet.Id);
        }

        public FlashCard ShownFlashCard
        {
            get => _shownFlashCard;
            set
            {
                _shownFlashCard = value;
                OnPropertyChanged();
            }
        }

        public FlashCardSet CurrentFlashCardSet
        {
            get => _currentFlashCardSet;
            set
            {
                _currentFlashCardSet = value;
                OnPropertyChanged();
            }
        }

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
            _currentFlashCardSet.Progress++;

        }



        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
