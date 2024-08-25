using FlashCardLearn.ViewModel;
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
    public class ExecuteCreateFlashCardCommand : CommandBase
    {
        private readonly CreateFlashCardViewModel _createFlashCardViewModel;
        private readonly FlashCardService _flashCardService;
        public ExecuteCreateFlashCardCommand(CreateFlashCardViewModel createFlashCardViewModel, FlashCardService flashCardService)
        {
            _createFlashCardViewModel = createFlashCardViewModel;
            _createFlashCardViewModel.PropertyChanged += OnViewModelChanged;
            _flashCardService = flashCardService;
        }

        public override bool CanExecute(object? parameter)
        {
            if(string.IsNullOrEmpty(_createFlashCardViewModel.Question) || string.IsNullOrEmpty(_createFlashCardViewModel.Awnser))
            {
                return false;
            }
            return true;
        }

        public override async void Execute(object? parameter)
        {
            await _flashCardService.CreateFlashCard(new FlashCard
            {
                Question = _createFlashCardViewModel.Question,
                Answer = _createFlashCardViewModel.Awnser,
                FlashcardsetId = _createFlashCardViewModel.SelectedFlashCardSet.Id
            });
            MessageBox.Show("Added");
        }

        private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName ==  nameof(CreateFlashCardViewModel.Question) || e.PropertyName == nameof(CreateFlashCardViewModel.Awnser))
            {
                OnCanExecutedChanged();
            }
                
        }
    }
}
