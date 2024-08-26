using FlashCardLearn.Services;
using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using Repositories.Models;
using Services;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace FlashCardLearn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
        }
    }

}
