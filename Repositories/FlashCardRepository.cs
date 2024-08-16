using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FlashCardRepository
    {
        private FlashCardLearnContext _context;
        public FlashCardRepository()
        {
            _context = new FlashCardLearnContext();
        }

        public async Task<IEnumerable<FlashCard>> GetFlashCardsAsync()
        {
            return await _context.FlashCards.ToListAsync();
        }
    }
}
