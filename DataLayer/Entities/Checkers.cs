using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Checkers
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Games")]
        public virtual int GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Games Games { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        [Required]
        [Display(Name = "Colors")]
        public virtual int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Colors Colors { get; set; }

        public bool IsQueen { get; set; }

        public bool IsEaten { get; set; }
    }
}
