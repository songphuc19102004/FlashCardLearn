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
    }
}
