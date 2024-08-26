using Repositories.Models;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class FlashCardMapper
    {
        public static FlashCardDTO ToFlashCardDTO(this FlashCard flashCard)
        {
            return new FlashCardDTO
            {
                Question = flashCard.Question,
                Answer = flashCard.Answer
            };
        }

        public static FlashCard ToFlashCard(this FlashCardDTO dTO)
        {
            return new FlashCard
            {
                Question = dTO.Question,
                Answer = dTO.Answer
            };
        }
    }
}
