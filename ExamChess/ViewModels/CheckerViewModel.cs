using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamChess.ViewModels
{
    public class CheckerViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Position { get; set; }
        public int ColorId { get; set; }
        public bool IsQueen { get; set; }
        public bool IsEaten { get; set; }
    }
}