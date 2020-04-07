using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ScrumBoard.Views
{
    /// <summary>
    /// Interaction logic for CardView.xaml
    /// </summary>
    public partial class CardView : UserControl
    {
        public Card Card { get; set; }

        public CardView(Card card)
        {
            Card = card;
            DataContext = Card;

            InitializeComponent();
        }

        private void editBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWindow window = new EditWindow(Card);
            window.ShowDialog();
        }

        private void moveLeftBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (Card.Membership)
            {
                case BoardList.DOING:
                    Card.Membership = BoardList.TODO;
                    break;
                case BoardList.DONE:
                    Card.Membership = BoardList.DOING;
                    break;
            }
        }

        private void moveRightBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (Card.Membership)
            {
                case BoardList.TODO:
                    Card.Membership = BoardList.DOING;
                    break;
                case BoardList.DOING:
                    Card.Membership = BoardList.DONE;
                    break;
            }
        }
    }

    public class PriorityToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CardPriority priority = (CardPriority)value;
            SolidColorBrush color = Brushes.White;
            switch (priority)
            {
                case CardPriority.LOW:
                    color = Brushes.LightGreen;
                    break;
                case CardPriority.MEDIUM:
                    color = Brushes.YellowGreen;
                    break;
                case CardPriority.HIGH:
                    color = Brushes.IndianRed;
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
