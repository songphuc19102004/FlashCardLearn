using FlashCardLearn.ViewModel;
using Repositories.Models;
using Services;
using Services.DTOs;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class ImportCommand : CommandBase
    {
        private FlashCardManagerViewModel _flashCardManagerViewModel;
        public ImportCommand(FlashCardManagerViewModel flashCardManagerViewModel)
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
        }

        public override void Execute(object? parameter)
        {
            var dtos = ImportExportHelper.ImportJsonToFlashcardList();
            if(dtos == null)
            {
                return;
            }
            var flashcards = ConvertDTOsToFlashCards(dtos);
            SaveFlashCardToDatabase(flashcards);
            UpdateViewModelFlashCards(flashcards);
        }
        private async void SaveFlashCardToDatabase(List<FlashCard> flashcards)
        {
            FlashCardService flashCardService = new FlashCardService();
            foreach(FlashCard fc in flashcards)
            {
                await flashCardService.CreateFlashCard(fc);
            }
        }
        private List<FlashCard> ConvertDTOsToFlashCards(List<FlashCardDTO> dtos)
        {
            return dtos.Select(dto => new FlashCard
            {
                Question = dto.Question,
                Answer = dto.Answer, // Note: There's a typo in your DTO (Awnser instead of Answer)
                FlashcardsetId = _flashCardManagerViewModel.SelectedFlashCardSet.Id
            }).ToList();
        }

        private void UpdateViewModelFlashCards(List<FlashCard> importedFlashcards)
        {
            foreach(var flashcard in importedFlashcards)
            {
                _flashCardManagerViewModel.FlashCards.Add(flashcard);
            }
            _flashCardManagerViewModel.UpdateFlashCards();
        }
    }
}
