using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class NavigateEditViewCommand : CommandBase
    {
        private FlashCardSet _selectedFlashCardSet;
        private NavigationStore _navigationStore;
        public NavigateEditViewCommand(FlashCardSet selectedFlashCardSet, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _selectedFlashCardSet = selectedFlashCardSet;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SaveFlashCardViewModel(_navigationStore, _selectedFlashCardSet, parameter as FlashCard);
        }
    }
}
