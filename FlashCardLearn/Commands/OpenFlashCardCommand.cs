using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using Microsoft.Identity.Client;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class OpenFlashCardCommand : CommandBase
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly NavigationStore _navigationStore;
        public OpenFlashCardCommand(HomeViewModel homeViewModel, NavigationStore navigationStore)
        {
            _homeViewModel = homeViewModel;
            _navigationStore = navigationStore;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            //open lean view usercontrol
            var selectedFlashCardSet = parameter as FlashCardSet;
            if(selectedFlashCardSet != null)
            {
                _navigationStore.CurrentViewModel = new FlashCardManagerViewModel(selectedFlashCardSet, false, _navigationStore);
            }
        }
    }
}
