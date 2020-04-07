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
using System.Windows.Shapes;

namespace ScrumBoard.Views
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
            DataContext = Card;

            BuildPriorityList();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Card.Priority = ProcessPriority();

            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BuildPriorityList()
        {
            foreach(CardPriority priority in Enum.GetValues(typeof(CardPriority))) {
                string title = priority.ToString().ToLower();
                title = title[0].ToString().ToUpper() + title.Substring(1);

                ComboBoxItem item = new ComboBoxItem
                {
                    Tag = priority,
                    Content = title
                };
                PriorInput.Items.Add(item);

                if (Card.Priority == priority)
                {
                    PriorInput.SelectedItem = item;
                }
            }
        }

        private CardPriority ProcessPriority()
        {
            ComboBoxItem selItem = (ComboBoxItem)PriorInput.SelectedItem;
            CardPriority tagValue = (CardPriority)selItem.Tag;
            return tagValue;
        }
    }
}
