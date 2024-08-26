using FlashCardLearn.ViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCardLearn.Commands
{
    public class ExportCommand : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        public ExportCommand(FlashCardManagerViewModel flashCardManagerViewModel)
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        } 
        public override void Execute(object? parameter)
        {
            ImportExportHelper.ExportFlashcardListToFile(_flashCardManagerViewModel.FlashCards);
        }
    }
}
