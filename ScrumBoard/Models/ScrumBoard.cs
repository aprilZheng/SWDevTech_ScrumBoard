using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Models
{
    public class ScrumBoardApp
    {
        public List<Card> Cards { get; }

        public ScrumBoardApp() {
            Cards = new List<Card>();
        }
    }
}
