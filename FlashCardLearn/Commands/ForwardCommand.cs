using FlashCardLearn.ViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            string FinishingSoundFilePath = SettingService.LoadSettings().FinishingSoundFilePath;
            if(_learnViewModel.Progress < _learnViewModel.CurrentFlashCards.Count - 1)
            {
                _learnViewModel.Progress++;
                _learnViewModel.ShownFlashCard = _learnViewModel.CurrentFlashCards[_learnViewModel.Progress.Value];
                _learnViewModel.IsQuestionVisible = true;
            }
            else
            {
                if(File.Exists(FinishingSoundFilePath))
                {
                    SoundPlayer soundPlayer = new SoundPlayer(FinishingSoundFilePath);
                    soundPlayer.Play();
                }
                MessageBox.Show("Congratulations!, You have finished this flash card set!", "Congrats", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
