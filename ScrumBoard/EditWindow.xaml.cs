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

namespace ScrumBoard
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public Card Card { get; }

        public EditWindow(Card cardIn)
        {
            InitializeComponent();

            Card = cardIn;
            TitleInput.Text = Card.Title;
            DescInput.Text = Card.Description;
        }
    }
}
