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
    public class SaveFlashCardCommand : CommandBase
    {
        private readonly SaveFlashCardViewModel _saveFlashCardViewModel;
        private readonly FlashCardService _flashCardService;
        public SaveFlashCardCommand(SaveFlashCardViewModel createFlashCardViewModel, FlashCardService flashCardService)
        {
            _saveFlashCardViewModel = createFlashCardViewModel;
            _saveFlashCardViewModel.PropertyChanged += OnViewModelChanged;
            _flashCardService = flashCardService;
        }

        public override bool CanExecute(object? parameter)
        {
            if(string.IsNullOrEmpty(_saveFlashCardViewModel.Question) || string.IsNullOrEmpty(_saveFlashCardViewModel.Awnser))
            {
                return false;
            }
            return true;
        }

        public override async void Execute(object? parameter)
        {
            if(_saveFlashCardViewModel.SelectedFlashCard == null)
            {
                //create
                await _flashCardService.CreateFlashCard(new FlashCard
                {
                    Question = _saveFlashCardViewModel.Question,
                    Answer = _saveFlashCardViewModel.Awnser,
                    FlashcardsetId = _saveFlashCardViewModel.SelectedFlashCardSet.Id
                });
            }
            else
            {
                _saveFlashCardViewModel.SelectedFlashCard.Question = _saveFlashCardViewModel.Question;
                _saveFlashCardViewModel.SelectedFlashCard.Answer = _saveFlashCardViewModel.Awnser;
                await _flashCardService.UpdateAsync(_saveFlashCardViewModel.SelectedFlashCard);
            }
            MessageBox.Show("Flash Card saved!");
            _saveFlashCardViewModel.Question = string.Empty;
            _saveFlashCardViewModel.Awnser = string.Empty;
        }

        private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_saveFlashCardViewModel.Question) || e.PropertyName == nameof(_saveFlashCardViewModel.Awnser))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
