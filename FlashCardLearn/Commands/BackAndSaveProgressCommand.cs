using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class BackAndSaveProgressCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public BackAndSaveProgressCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override async void Execute(object? parameter)
        {
            FlashCardSetService flashCardSetService = new();
            await flashCardSetService.UpdateAsync(parameter as FlashCardSet);
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
    }
}
