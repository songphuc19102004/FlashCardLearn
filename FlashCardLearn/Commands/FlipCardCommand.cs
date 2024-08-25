using FlashCardLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class FlipCardCommand : CommandBase
    {
        private readonly LearnViewModel _learnViewModel;

        public FlipCardCommand(LearnViewModel learnViewModel)
        {
            _learnViewModel = learnViewModel;
        }

        public override void Execute(object? parameter)
        {
            _learnViewModel.IsQuestionVisible = !_learnViewModel.IsQuestionVisible;
        }   
    }
}
