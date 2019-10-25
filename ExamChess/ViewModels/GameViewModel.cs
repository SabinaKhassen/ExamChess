using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamChess.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public int PlayerOne { get; set; }
        public int PlayerTwo { get; set; }
        public int ColorOneId { get; set; }
        public int ColorTwoId { get; set; }
        public int ChessTypeId { get; set; }
        public DateTime BeginGame { get; set; }
        public DateTime EndGame { get; set; }
        public int WinnerId { get; set; }
    }
}