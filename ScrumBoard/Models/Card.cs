using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Models
{
    public class Card : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string Title {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    TriggerPropertyChanged("Title");
                }
            }
        }

        private string description;
        public string Description {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    TriggerPropertyChanged("Description");
                }
            }
        }

        private CardPriority priority;
        public CardPriority Priority { get => priority;
            set
            {
                if (priority != value)
                {
                    priority = value;
                    TriggerPropertyChanged("Priority");
                }
            }
        }

        private DateTime? dueDate;
        public DateTime? DueDate {
            get => dueDate;
            set
            {
                dueDate = value;
                if (dueDate == null)
                {
                    DueDateText = null;
                }
                else
                {
                    DateTime nonNullable = (DateTime)dueDate;
                    DueDateText = nonNullable.ToString("yyyy-MM-dd H:m:s");
                }
            }
        }

        private string dueDateText;
        public string DueDateText
        {
            get => dueDateText;
            set
            {
                if (dueDateText != value)
                {
                    dueDateText = value;
                    TriggerPropertyChanged("DueDateText");
                }
            }
        }

        private BoardList membership;
        public BoardList Membership
        {
            get => membership;
            set
            {
                if (membership != value)
                {
                    membership = value;
                    TriggerPropertyChanged("Membership");
                }
            }
        }

        private void TriggerPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
