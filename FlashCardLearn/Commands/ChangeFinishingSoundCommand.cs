using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashCardLearn.Commands
{
    public class ChangeFinishingSoundCommand : CommandBase
    {
        private readonly SettingViewModel _settingViewModel;
        public ChangeFinishingSoundCommand(SettingViewModel settingViewModel)
        {
            _settingViewModel = settingViewModel;
        }
        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "WAV files (*.wav)|*.wav",
                Title = "Select a WAV File"
            };

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                Settings settings = new Settings()
                {
                    FinishingSoundFilePath = selectedFilePath
                };
                _settingViewModel.FinishingSoundFilePath = selectedFilePath;
            }
        }
    }
}
