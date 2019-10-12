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
        public int BoardColorId { get; set; }
        public int ChessTypeId { get; set; }
    }
}