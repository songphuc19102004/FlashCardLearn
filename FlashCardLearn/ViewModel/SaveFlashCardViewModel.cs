using FlashCardLearn.Commands;
using FlashCardLearn.Services;
using FlashCardLearn.Stores;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class SaveFlashCardViewModel : ViewModelBase
    {
        public ICommand BackToFlashCardManagerViewCommand { get; }
        public ICommand SaveFlashCardCommand { get; }
        private FlashCardService _flashCardService;

        public SaveFlashCardViewModel(NavigationStore navigationStore, FlashCardSet selectedFlashCardSet, FlashCard? selectedFlashCard = null)
        {
            _flashCardService = new FlashCardService();
            _selectedFlashCardSet = selectedFlashCardSet;
            BackToFlashCardManagerViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new FlashCardManagerViewModel(selectedFlashCardSet, false, navigationStore)));
            SaveFlashCardCommand = new SaveFlashCardCommand(this, _flashCardService);
            _selectedFlashCard = selectedFlashCard;
        }

        private string _question;
        public string Question
        {
            get
            {
                if(_selectedFlashCard == null)
                {
                    return _question;
                }
                return _selectedFlashCard.Question;
            }
            set
            {
                if(_selectedFlashCard == null)
                {
                    _question = value;
                }
                else
                {
                    _selectedFlashCard.Question = value;
                }
                OnPropertyChanged();
            }
        }

        private string _awnser;
        public string Awnser
        {
            get
            {
                if(_selectedFlashCard == null)
                {
                    return _awnser;
                }
                return _selectedFlashCard.Answer;
            }
            set
            {
                if(_selectedFlashCard == null)
                {
                    _awnser = value;
                }
                else
                {
                    _selectedFlashCard.Answer = value;
                }
                OnPropertyChanged();
            }
        }

        private bool _isCreate;
        public bool IsCreate
        {
            get => _isCreate;
            set
            {
                _isCreate = value;
            }
        }

        private FlashCardSet _selectedFlashCardSet;
        public FlashCardSet SelectedFlashCardSet
        {
            get => _selectedFlashCardSet;
            set
            {
                _selectedFlashCardSet = value;
            }
        }

        private FlashCard? _selectedFlashCard;
        public FlashCard? SelectedFlashCard
        {
            get => _selectedFlashCard;
            set
            {
                _selectedFlashCard = value;
            }
        }

    }
}
