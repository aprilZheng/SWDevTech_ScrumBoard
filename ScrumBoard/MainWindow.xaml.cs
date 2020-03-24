using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ScrumBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Properties
        public List<Card> TodoList { get; }
        public List<Card> DoingList { get; }
        public List<Card> DoneList { get; }

        private Dictionary<string, List<Card>> labelMapping =
            new Dictionary<string, List<Card>>();

        public MainWindow()
        {
            InitializeComponent();

            TodoList = new List<Card>();
            labelMapping.Add("To Do", TodoList);
            DoingList = new List<Card>();
            labelMapping.Add("Doing", DoingList);
            DoneList = new List<Card>();
            labelMapping.Add("Done", DoneList);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string label = GetColumnLabel(sender);
            List<Card> column = labelMapping[label];

            Card newCard = new Card
            {
                Height = 150
            };
            newCard.Title = "Title of new card";
            newCard.Description = "Description of new card";
            newCard.Priority = CardPriority.LOW;

            column.Add(newCard);
            GetContainer(sender).Children.Add(newCard);
        }

        private string GetColumnLabel(object sender)
        {
            Button senderBtn = (Button)sender;
            Grid grid = (Grid)senderBtn.Parent;
            TextBlock label = (TextBlock)grid.Children[1];

            return label.Text;
        }

        private StackPanel GetContainer(object sender)
        {
            Button senderBtn = (Button)sender;
            Grid grid = (Grid)senderBtn.Parent;
            ScrollViewer container = (ScrollViewer)grid.Children[4];

            return (StackPanel)container.Content;
        }
    }
}
