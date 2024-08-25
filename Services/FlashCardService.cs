using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Security.Principal;

namespace Services
{
    public class FlashCardService
    {
        private FlashCardRepository _flashCardRepository;
        public FlashCardService() 
        {
            _flashCardRepository = new FlashCardRepository();
        }
        
        public async Task<IEnumerable<FlashCard>> GetFlashCardsAsync()
        {
            return await _flashCardRepository.GetFlashCardsAsync();
        }

        public ObservableCollection<FlashCard> GetFlashCardsBySetId(int id)
        {
            return _flashCardRepository.GetFlashCardsBySetId(id);
        }

        public async Task<bool> CreateFlashCard(FlashCard flashCard)
        {
            return await _flashCardRepository.CreateFlashCard(flashCard);
        }

        public async Task<bool> RemoveFlashCard(int id)
        {
            return await _flashCardRepository.RemoveFlashCardAsync(id);
        }

        public async Task<bool> RemoveFlashCardOfSetAsync(int setId)
        {
            return await _flashCardRepository.RemoveFlashCardOfSetAsync(setId);
        }

        public async Task<bool> UpdateAsync(FlashCard flashCard)
        {
            return await _flashCardRepository.UpdateAsync(flashCard);
        }
    }
}
