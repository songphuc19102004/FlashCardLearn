using FlashCardLearn.Commands;
using FlashCardLearn.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class ImportViewModel : ViewModelBase
    {
        public ImportViewModel(FlashCardManagerViewModel _flashCardManagerViewModel, NavigationStore navigationStore) 
        {
            BackToFlashCardManagerCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => _flashCardManagerViewModel));
            ImportQuizletCommand = new ImportQuizletCommand(_flashCardManagerViewModel, this);
        }

        private string _textBoxContent;
        public string TextBoxContent
        {
            get => _textBoxContent;
            set
            {
                _textBoxContent = value;
                OnPropertyChanged();
            }
        }

        public ICommand ImportQuizletCommand { get; }
        public ICommand BackToFlashCardManagerCommand { get; }
    }
}
