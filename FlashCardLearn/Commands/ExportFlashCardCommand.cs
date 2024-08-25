using FlashCardLearn.ViewModel;
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
    public class ExportFlashCardCommand : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        public ExportFlashCardCommand(FlashCardManagerViewModel flashCardManagerViewModel)
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
            _flashCardManagerViewModel.PropertyChanged += OnViewModelPropertyChanged; 
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        } 
        public override void Execute(object? parameter)
        {
            Debug.WriteLine("Executed");
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }
}
