using FlashCardLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCardLearn.Commands
{
    public class ForwardCommand : CommandBase
    {
        private readonly LearnViewModel _learnViewModel;

        public ForwardCommand(LearnViewModel learnViewModel)
        {
            _learnViewModel = learnViewModel;
        }

        public override void Execute(object? parameter)
        {
            if(_learnViewModel.Progress < _learnViewModel.CurrentFlashCards.Count - 1)
            {
                _learnViewModel.Progress++;
                _learnViewModel.ShownFlashCard = _learnViewModel.CurrentFlashCards[_learnViewModel.Progress.Value];
                _learnViewModel.IsQuestionVisible = true;
            }
            else
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Phuc\Desktop\repo2\FlashCardLearn\FlashCardLearn\Resources\Sounds\children_yay.wav");
                soundPlayer.Play();
                MessageBox.Show("Congratulations!, You have finished this flash card set!", "Congrats", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
