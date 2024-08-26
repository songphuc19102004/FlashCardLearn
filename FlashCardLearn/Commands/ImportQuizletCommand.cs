using FlashCardLearn.ViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class ImportQuizletCommand : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        private readonly ImportViewModel _importViewModel;
        public ImportQuizletCommand(FlashCardManagerViewModel flashCardManagerViewModel, ImportViewModel importViewModel)
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
            _importViewModel = importViewModel;
            _importViewModel.PropertyChanged += OnViewModelChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            if(string.IsNullOrEmpty(_importViewModel.TextBoxContent))
            {
                return false;
            }
            return true;
        }

        public override void Execute(object? parameter)
        {
            var importedFlashcards = ImportExportHelper.QuizletImportToFlashCardList(_importViewModel.TextBoxContent);
        }

        private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ImportViewModel.TextBoxContent))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
