using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        private string _finishingSoundEffectName;
        private ICommand _changeFinishingSoundEffectCommand;
        public SettingViewModel() { }

        public string FinishingSoundEffectName
        {
            get => _finishingSoundEffectName;
        }

        public ICommand ChangeFinishingSoundEffectCommand;
    }
}
