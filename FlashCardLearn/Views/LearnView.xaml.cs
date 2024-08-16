using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for LearnView.xaml
    /// </summary>
    public partial class LearnView : Window
    {
        private List<string> quotes = new List<string>()
        {
            "\"Tell me and I forget, teach me and I may remember, involve me and I learn\"",
            "\"The more that you read, the more things you will know. The more that you learn, the more places you’ll go\"",
            "\"Live as if you were to die tomorrow. Learn as if you were to live forever\"",
            "\"In learning you will teach, and in teaching you will learn\"",
            "\"Learning never exhausts the mind\"",
            "\"For the things we have to learn before we can do them, we learn by doing them\"",
            "\"Leadership and learning are indispensable to each other\"",
            "\"Wisdom…. comes not from age, but from education and learning\"",
            "\"For the best return on your money, pour your purse into your head\"",
            "\"I am always doing that which I cannot do, in order that I may learn how to do it\"",
            "\"Learn as if you were not reaching your goal and as though you were scared of missing it\"",
            "\"Intellectual growth should commence at birth and cease only at death\"",
            "\"The beautiful thing about learning is that nobody can take it away from you\"",
            "\"Anyone who stops learning is old, whether at twenty or eighty. Anyone who keeps learning stays young\""
        };
        public LearnView()
        {
            InitializeComponent();
            Random rand = new Random();
            this.Title = quotes[rand.Next(0, 15)];
        }
    }
}
