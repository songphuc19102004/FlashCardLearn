using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FlashCardSetRepository
    {
        private FlashCardLearnContext _context;

        public FlashCardSetRepository()
        {
            _context = new FlashCardLearnContext();
        }

        public async Task<IEnumerable<FlashCardSet>> GetFlashCardSetsAsync()
        {
            return await _context.FlashCardSets.ToListAsync();
        }
    }
}
