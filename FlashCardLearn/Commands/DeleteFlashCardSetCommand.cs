using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCardLearn.Commands
{
    public class DeleteFlashCardSetCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private FlashCardSet _selectedFlashCardSet;

        public DeleteFlashCardSetCommand(NavigationStore navigationStore, FlashCardSet selectedFlashCardSet)
        {
            _navigationStore = navigationStore;
            _selectedFlashCardSet = selectedFlashCardSet;
        }
        public override async void Execute(object? parameter)
        {
            var isConfirm = MessageBox.Show("Are you sure want to delete this set?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(MessageBoxResult.Yes == isConfirm)
            {
                FlashCardService flashCardService = new();
                FlashCardSetService flashCardSetService = new();
                await flashCardService.RemoveFlashCardOfSetAsync(_selectedFlashCardSet.Id);
                await flashCardSetService.RemoveFlashCardSetAsync(_selectedFlashCardSet.Id);
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            }
        }
    }
}
