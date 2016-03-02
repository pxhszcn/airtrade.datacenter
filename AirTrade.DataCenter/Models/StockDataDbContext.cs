namespace AirTrade.DataCenter.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StockDataDbContext : DbContext
    {
        public StockDataDbContext()
            : base("name=StockData")
        {
        }

        public virtual DbSet<StockBasic> stock_basic { get; set; }
        public virtual DbSet<StockIndex> stock_index { get; set; }
        public virtual DbSet<StockTodayAll> stock_today_all { get; set; }
    }
}
