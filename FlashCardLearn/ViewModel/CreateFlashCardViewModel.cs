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
    public class CreateFlashCardViewModel : ViewModelBase
    {
        public ICommand BackToFlashCardManagerViewCommand { get; }
        public ICommand ExecuteCreateFlashCardCommand { get; }
        private FlashCardService _flashCardService;

        public CreateFlashCardViewModel(NavigationStore navigationStore, FlashCardSet selectedFlashCardSet)
        {
            _flashCardService = new FlashCardService();

            _selectedFlashCardSet = selectedFlashCardSet;
            BackToFlashCardManagerViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new FlashCardManagerViewModel(selectedFlashCardSet, false, navigationStore)));
            ExecuteCreateFlashCardCommand = new ExecuteCreateFlashCardCommand(this, _flashCardService);

        }

        private string _question;
        public string Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        private string _awnser;
        public string Awnser
        {
            get => _awnser;
            set
            {
                _awnser = value;
                OnPropertyChanged();
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
    }
}
