using FlashCardLearn.ViewModel;
using Repositories.Models;
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
    public class DeleteFlashCardCommand : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        public DeleteFlashCardCommand(FlashCardManagerViewModel flashCardManagerViewModel)
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
            _flashCardManagerViewModel.PropertyChanged += OnViewModelChanged;
        }

        public override async void Execute(object? parameter)
        {
            var flashCard = parameter as FlashCard;
            var isConfirm = MessageBox.Show("Are you sure to delete this flash card?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBoxResult.Yes == isConfirm)
            {
                FlashCardService flashCardService = new FlashCardService();
                await flashCardService.RemoveFlashCard(flashCard.Id);
                _flashCardManagerViewModel.FlashCards.Remove(flashCard);
            }
        }
        private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            var a = e.PropertyName;
        }
    }
}
