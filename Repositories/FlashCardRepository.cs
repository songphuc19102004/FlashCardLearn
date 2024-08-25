using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<FlashCard> GetFlashCardsBySetId(int id)
        {
            var result = _context.FlashCards.Where(fc => fc.FlashcardsetId == id);
            return new ObservableCollection<FlashCard>(result);
        }

        public async Task<bool> CreateFlashCard(FlashCard flashCard)
        {
            _context.FlashCards.Add(flashCard);
            return await SaveChangesAsync();
        }

        public async Task<bool> RemoveFlashCardAsync(int id)
        {
            var found = await _context.FlashCards.FirstOrDefaultAsync(fc => fc.Id == id);
            _context.FlashCards.Remove(found);
            return await SaveChangesAsync();
        }

        public async Task<bool> RemoveFlashCardOfSetAsync(int setId)
        {
            var found = _context.FlashCards.Where(fc => fc.FlashcardsetId == setId);
            _context.FlashCards.RemoveRange(found);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(FlashCard flashCard)
        {
            _context.Entry(flashCard).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
