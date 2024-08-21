using FlashCardLearn.Views;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlashCardLearn.ViewModel
{
    public class FlashCardManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private FlashCardSet _selectedFlashCardSet;
        private ObservableCollection<FlashCard> _flashCards;
        private FlashCardService _flashCardService;
        private FlashCardSetService _flashCardSetService;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ICommand _learnCommand;
        public Action Close { get; set; }

        public FlashCardManagerViewModel()
        {
            _flashCardService = new FlashCardService();
            _flashCardSetService = new FlashCardSetService();
        }

        public FlashCardSet SelectedFlashCardSet
        {
            get => _selectedFlashCardSet;
            set
            {
                _selectedFlashCardSet = value;
                OnPropertyChanged();
                InitializeFlashCards();
            }
        }

        public ObservableCollection<FlashCard> FlashCards
        {
            get => _flashCards;
            set
            {
                _flashCards = value;
                OnPropertyChanged();
            }
        }

        public bool IsVisibleLearn
        {
            get
            {
                if(_flashCards.Count == 0)
                {
                    return false;
                }
                else return true;
            }
        }


        #region Edit
        public ICommand EditCommand
        {
            get
            {
                if( _editCommand == null)
                {
                    _editCommand = new RelayCommand(Edit, CanEdit);
                }
                return _editCommand;
            }
        }

        private bool CanEdit(object obj)
        {
            return true;
        }

        private void Edit(object obj) 
        {
            MessageBox.Show("Edit");
        }
        #endregion

        #region Delete
        public ICommand DeleteCommand
        {
            get
            {
                if(_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(Delete, CanDelete);
                }
                return _deleteCommand;
            }
        }

        private bool CanDelete(object obj)
        {
            return true;
        }

        private void Delete(object obj) 
        {
            MessageBox.Show("Del");
        }
        #endregion

        #region Learn
        public ICommand LearnCommand
        {
            get
            {
                if(_learnCommand == null)
                {
                    _learnCommand = new RelayCommand(Learn, CanLearn);
                }
                return _learnCommand;
            }
        }

        private bool CanLearn(object obj)
        {
            return true;
        }

        private void Learn(object obj)
        {
            var learnViewModel = new LearnViewModel();
            learnViewModel.CurrentFlashCardSet = _selectedFlashCardSet;
            var managerWindow = obj as Window;
            managerWindow.Close();

            LearnView learnView = new LearnView();
            learnView.DataContext = learnViewModel;
            learnView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            learnView.ShowDialog();
        }
        #endregion

        private void InitializeFlashCards()
        {
            if(_selectedFlashCardSet != null)
            {
                _flashCards = new ObservableCollection<FlashCard>(_flashCardService.GetFlashCardsBySetId(_selectedFlashCardSet.Id));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
