using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using System.Collections;
using System.Security.Principal;

namespace Services
{
    public class FlashCardSetService
    {
        private FlashCardSetRepository _flashCardSetRepository;
        public FlashCardSetService()
        {
            _flashCardSetRepository = new FlashCardSetRepository();
        }

        public async Task<IEnumerable<FlashCardSet>> GetFlashCardSetsAsync()
        {
            return await _flashCardSetRepository.GetFlashCardSetsAsync();
        }

        public async Task<bool> UpdateAsync(FlashCardSet flashCardSet)
        {
            return await _flashCardSetRepository.UpdateAsync(flashCardSet);
        }

        public async Task<int> GetFlashCardCountForSetAsync(int flashcardsetId)
        {
            return await _flashCardSetRepository.GetFlashCardCountForSetAsync(flashcardsetId);
        }
        public async Task<bool> CreateFlashCardSet(FlashCardSet flashCardSet)
        {
            return await _flashCardSetRepository.CreateFlashCardSet(flashCardSet);
        }
        public async Task<bool> RemoveFlashCardSetAsync(int flashcardsetId)
        {
            return await _flashCardSetRepository.RemoveFlashCardSetAsync(flashcardsetId);
        }
    }
}
