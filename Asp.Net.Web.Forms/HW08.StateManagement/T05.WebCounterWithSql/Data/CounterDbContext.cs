using System.Data.Entity;
using T05.WebCounterWithSql.Models;

namespace T05.WebCounterWithSql.Data
{
    public class CounterDbContext : DbContext
    {
        public CounterDbContext()
            : base("CounterDb")
        {
        }

        public virtual IDbSet<Counter> Counters { get; set; }
    }
}
