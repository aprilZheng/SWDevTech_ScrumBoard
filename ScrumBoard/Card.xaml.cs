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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScrumBoard
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        private string title_;
        private string description_;

        public string Title {
            get
            {
                return title_;
            }
            set
            {
                title_ = value;
                GuiTitle.Text = title_;
            }
        }
        public string Description {
            get
            {
                return description_;
            }
            set
            {
                description_ = value;
                GuiDescription.Text = description_;
            }
        }

        public Card()
        {
            InitializeComponent();

            Grid grid = (Grid)Content;
            Border card = (Border)grid.Children[0];
            card.Background = Brushes.White;
        }
    }
}
