using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace ScrumBoard
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        //TODO: Create priorities. Low, medium, high.
        // If the priority changes, change the color of the card.
        private string title_;
        private string description_;
        private CardPriority priority_;

        private Dictionary<CardPriority, SolidColorBrush> colorMapping = new Dictionary<CardPriority, SolidColorBrush> {
            {CardPriority.HIGH, Brushes.IndianRed},
            {CardPriority.LOW, Brushes.LightGreen},
            {CardPriority.MEDIUM, Brushes.Wheat}
        };

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
        public CardPriority Priority
        {
            get
            {
                return priority_;
            }
            set
            {
                priority_ = value;
                ChangeBackgroundColor(colorMapping[priority_]);
            }
        }

        public Card()
        {
            InitializeComponent();

            ChangeBackgroundColor(Brushes.White);
        }

        private void ChangeBackgroundColor(SolidColorBrush color)
        {
            Grid grid = (Grid)Content;
            Border card = (Border)grid.Children[0];
            card.Background = color;
        }

        private void editBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWindow window = new EditWindow(this);
            window.ShowDialog();
        }
    }
}
