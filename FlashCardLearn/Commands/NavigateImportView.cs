using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class NavigateImportView : CommandBase
    {
        private readonly FlashCardManagerViewModel _flashCardManagerViewModel;
        private readonly NavigationStore _navigationStore;
        public NavigateImportView(NavigationStore navigationStore, FlashCardManagerViewModel flashCardManagerViewModel)
        {
            _navigationStore = navigationStore;
            _flashCardManagerViewModel = flashCardManagerViewModel;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ImportViewModel(_flashCardManagerViewModel, _navigationStore);
        }
    }
}
