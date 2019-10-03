using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamChess.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }
        public int RoleId { get; set; }
    }
}