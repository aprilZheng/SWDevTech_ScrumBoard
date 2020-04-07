using ScrumBoard.Models;
using ScrumBoard.Views;
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
        public ScrumBoardApp Board { get; }

        public MainWindow()
        {
            InitializeComponent();

            Board = new ScrumBoardApp();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string label = GetColumnLabel(sender);

            // --- MODEL ---
            Card newCard = new Card();
            newCard.Title = "Title of new card";
            newCard.Description = "Description of new card";
            newCard.Priority = CardPriority.LOW;

            Board.Cards.Add(newCard);

            // --- VIEW ---
            CardView cardView = new CardView(newCard);
            cardView.Height = 150;

            // --- VIEW + MODEL ---
            switch (label)
            {
                case "To Do":
                    newCard.Membership = BoardList.TODO;
                    TodoContainer.Children.Add(cardView);
                    break;
                case "Doing":
                    newCard.Membership = BoardList.DOING;
                    DoingContainer.Children.Add(cardView);
                    break;
                case "Done":
                    newCard.Membership = BoardList.DONE;
                    DoneContainer.Children.Add(cardView);
                    break;
            }

            newCard.PropertyChanged += (s, evt) =>
            {
                if (evt.PropertyName == "Membership")
                {
                    CardView view;

                    view = GetCardFromBoard(TodoContainer.Children, newCard) ??
                        GetCardFromBoard(DoingContainer.Children, newCard) ??
                        GetCardFromBoard(DoneContainer.Children, newCard);

                    switch (newCard.Membership)
                    {
                        case BoardList.TODO:
                            TodoContainer.Children.Add(view);
                            break;
                        case BoardList.DOING:
                            DoingContainer.Children.Add(view);
                            break;
                        case BoardList.DONE:
                            DoneContainer.Children.Add(view);
                            break;
                    }
                }
            };

        }

        private string GetColumnLabel(object sender)
        {
            Button senderBtn = (Button)sender;
            Grid grid = (Grid)senderBtn.Parent;
            TextBlock label = (TextBlock)grid.Children[1];

            return label.Text;
        }

        private CardView GetCardFromBoard(UIElementCollection column, Card card)
        {
            foreach (CardView view in column)
            {
                if (view.DataContext == card)
                {
                    column.Remove(view);
                    return view;
                }
            }

            return null;
        }
    }
}
