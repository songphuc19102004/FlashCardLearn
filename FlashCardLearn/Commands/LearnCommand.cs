using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class LearnCommand : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        private readonly NavigationStore _navigationStore;
        public LearnCommand(NavigationStore navigationStore, FlashCardManagerViewModel flashCardManagerViewModel) 
        {
            _flashCardManagerViewModel = flashCardManagerViewModel;
            _navigationStore = navigationStore;
        }

        public override bool CanExecute(object? parameter)
        {
            if(_flashCardManagerViewModel.FlashCards.Count == 0)
            {
                return false && base.CanExecute(parameter);
            }

            return true && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new LearnViewModel(_flashCardManagerViewModel.SelectedFlashCardSet, _navigationStore);
        }
    }
}
