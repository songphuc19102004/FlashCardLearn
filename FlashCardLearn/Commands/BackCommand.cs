using FlashCardLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class BackCommand : CommandBase
    {
        private readonly LearnViewModel _learnViewModel;

        public BackCommand(LearnViewModel learnViewModel)
        {
            _learnViewModel = learnViewModel;
        }
        public override void Execute(object? parameter)
        {
            if(_learnViewModel.Progress > 0)
            {
                _learnViewModel.Progress--;
                _learnViewModel.ShownFlashCard = _learnViewModel.CurrentFlashCards[_learnViewModel.Progress.Value];
            }
        }
    }
}
