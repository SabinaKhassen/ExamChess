namespace DataLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        public int Id { get; set; }

        public int PlayerOne { get; set; }

        public int PlayerTwo { get; set; }

        public int BoardColorId { get; set; }

        public int ChessTypeId { get; set; }

        public DateTime BeginGame { get; set; }

        public DateTime EndGame { get; set; }

        public virtual BoardColors BoardColors { get; set; }

        [ForeignKey("ChessTypeId")]
        public virtual ChessTypes ChessTypes { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
