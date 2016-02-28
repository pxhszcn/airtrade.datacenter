namespace AirTrade.DataCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock_data.stock_index")]
    public partial class StockIndex
    {
        [Key]
        [StringLength(6)]
        public string code { get; set; }

        [StringLength(8)]
        public string name { get; set; }

        public double? change { get; set; }

        public double? open { get; set; }

        public double? preclose { get; set; }

        public double? close { get; set; }

        public double? high { get; set; }

        public double? low { get; set; }

        public long? volume { get; set; }

        public double? amount { get; set; }
    }
}
