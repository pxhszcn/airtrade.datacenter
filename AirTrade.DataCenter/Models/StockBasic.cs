namespace AirTrade.DataCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock_data.stock_basic")]
    public partial class StockBasic
    {
        [Key]
        [StringLength(6)]
        public string code { get; set; }

        [StringLength(8)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string industry { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string area { get; set; }

        public double? pe { get; set; }

        public double? outstanding { get; set; }

        public double? totals { get; set; }

        public double? totalAssets { get; set; }

        public double? liquidAssets { get; set; }

        public double? fixedAssets { get; set; }

        public double? reserved { get; set; }

        public double? reservedPerShare { get; set; }

        public double? esp { get; set; }

        public double? bvps { get; set; }

        public double? pb { get; set; }

        public long? timeToMarket { get; set; }
    }
}
