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
    }
}
