using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Models
{
    public class Card
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CardPriority Priority { get; set; }
        public BoardList Membership { get; set; }
    }
}
