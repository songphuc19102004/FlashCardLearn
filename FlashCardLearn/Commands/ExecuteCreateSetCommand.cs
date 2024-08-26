using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCardLearn.Commands
{
    public class ExecuteCreateSetCommand : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        private readonly NavigationStore _navigationStore;
        public ExecuteCreateSetCommand(NavigationStore navigationStore, FlashCardManagerViewModel flashCardManagerViewModel) 
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
            _navigationStore = navigationStore;
            _flashCardManagerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            if(_flashCardManagerViewModel.SelectedFlashCardSet.Title.Equals("Enter your set name", StringComparison.OrdinalIgnoreCase))
            {
                return false && base.CanExecute(parameter);
            }

            return true && base.CanExecute(parameter);
        }
        public override async void Execute(object? parameter)
        {
            FlashCardSetService flashCardSetService = new();
            var flashCardSet = await flashCardSetService.CreateFlashCardSet(new FlashCardSet
            {
                Title = _flashCardManagerViewModel.Title,
                FlashCards = _flashCardManagerViewModel.FlashCards
            });
            _flashCardManagerViewModel.IsCreate = false;
            _flashCardManagerViewModel.IsLearn = true;
            _flashCardManagerViewModel.CanOptions = true;
            _flashCardManagerViewModel.SelectedFlashCardSet = flashCardSet;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(FlashCardManagerViewModel.SelectedFlashCardSet.Title))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
