using ScrumBoard.Models;
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

            ChangeBackgroundColor(Card.Priority);
        }

        private void ChangeBackgroundColor(CardPriority priority)
        {
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

            Grid grid = (Grid)Content;
            Border card = (Border)grid.Children[0];
            card.Background = color;
        }

        private void editBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWindow window = new EditWindow(Card);
            window.ShowDialog();
        }

        private void moveLeftBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (mainWindow_.DoingList.Contains(this))
            //{
            //    mainWindow_.DoingList.Remove(this);
            //    mainWindow_.DoingContainer.Children.Remove(this);
            //    mainWindow_.TodoList.Add(this);
            //    mainWindow_.TodoContainer.Children.Add(this);
            //}
            //else if (mainWindow_.DoneList.Contains(this))
            //{
            //    mainWindow_.DoneList.Remove(this);
            //    mainWindow_.DoneContainer.Children.Remove(this);
            //    mainWindow_.DoingList.Add(this);
            //    mainWindow_.DoingContainer.Children.Add(this);
            //}
        }

        private void moveRightBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (mainWindow_.TodoList.Contains(this))
            //{
            //    mainWindow_.TodoList.Remove(this);
            //    mainWindow_.TodoContainer.Children.Remove(this);
            //    mainWindow_.DoingList.Add(this);
            //    mainWindow_.DoingContainer.Children.Add(this);
            //}
            //else if (mainWindow_.DoingList.Contains(this))
            //{
            //    mainWindow_.DoingContainer.Children.Remove(this);
            //    mainWindow_.DoingList.Remove(this);
            //    mainWindow_.DoneList.Add(this);
            //    mainWindow_.DoneContainer.Children.Add(this);
            //}
        }
    }
}
