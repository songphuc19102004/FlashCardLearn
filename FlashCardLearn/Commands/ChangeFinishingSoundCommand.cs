using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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
                if(IsValidWavFile(selectedFilePath))
                {
                    Settings settings = new Settings()
                    {
                        FinishingSoundFilePath = selectedFilePath
                    };
                    _settingViewModel.FinishingSoundFilePath = selectedFilePath;
                }
                else
                {
                    MessageBox.Show("The selected file is not a valid WAV file. Please make sure to select an authentic WAV file and avoid renaming or changing the extension of an MP3 file to WAV. You can use MP3 to WAV Converter online.", "Invalid WAV file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidWavFile(string filePath)
        {
            try
            {
                using(FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using(BinaryReader reader = new BinaryReader(fs))
                    {
                        // Check the RIFF header
                        string riff = new string(reader.ReadChars(4));
                        if(riff != "RIFF")
                            return false;

                        reader.ReadInt32(); // Skip 4 bytes (file size)

                        // Check the WAVE header
                        string wave = new string(reader.ReadChars(4));
                        if(wave != "WAVE")
                            return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
