using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class OpenCreateFlashCardViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly FlashCardSet _selectedFlashCardSet;

        public OpenCreateFlashCardViewCommand(NavigationStore navigationStore, FlashCardSet selectedFlashCardSet)
        {
            _navigationStore = navigationStore;
            _selectedFlashCardSet = selectedFlashCardSet;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new CreateFlashCardViewModel(_navigationStore, _selectedFlashCardSet);
        }
    }
}
