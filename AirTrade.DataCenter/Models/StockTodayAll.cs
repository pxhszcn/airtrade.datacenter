namespace AirTrade.DataCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock_data.stock_today_all")]
    public partial class StockTodayAll
    {
        [Key]
        [StringLength(6)]
        public string code { get; set; }

        [StringLength(8)]
        public string name { get; set; }

        public double? changepercent { get; set; }

        public double? trade { get; set; }

        public double? open { get; set; }

        public double? high { get; set; }

        public double? low { get; set; }

        public double? settlement { get; set; }

        public long? volume { get; set; }

        public double? turnoverratio { get; set; }

        public long? amount { get; set; }

        public double? per { get; set; }

        public double? pb { get; set; }

        public double? mktcap { get; set; }

        public double? nmc { get; set; }
    }
}
