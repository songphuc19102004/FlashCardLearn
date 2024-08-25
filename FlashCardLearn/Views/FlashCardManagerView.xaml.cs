using FlashCardLearn.ViewModel;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlashCardLearn.Views
{
    /// <summary>
    /// Interaction logic for FlashCardManagerView.xaml
    /// </summary>
    public partial class FlashCardManagerView : UserControl
    {
        public FlashCardManagerView()
        {
            InitializeComponent();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can add/edit/delete flash card by using the grid below", "Guide", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
