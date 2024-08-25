using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class OpenCreateFlashCardViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        public OpenCreateFlashCardViewCommand(NavigationStore navigationStore, FlashCardManagerViewModel flashCardManagerViewModel)
        {
            _navigationStore = navigationStore;
            _flashCardManagerViewModel = flashCardManagerViewModel;
            _flashCardManagerViewModel.PropertyChanged += OnViewModelChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            if(_flashCardManagerViewModel.IsCreate)
            {
                return false;
            }
            return true;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SaveFlashCardViewModel(_navigationStore, _flashCardManagerViewModel.SelectedFlashCardSet);
        }

        private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(FlashCardManagerViewModel.IsCreate))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
