using System.Data.Entity;

namespace DBInsertSpeedTests {
    public class InsertTestContext : DbContext
    {
        public InsertTestContext()
            : base("name=InsertTestContext") { }

        public virtual DbSet<InsertTestType1> InsertTestTypes1 { get; set; }
        public virtual DbSet<InsertTestType2> InsertTestTypes2 { get; set; }
        public virtual DbSet<InsertTestType3> InsertTestTypes3 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}
