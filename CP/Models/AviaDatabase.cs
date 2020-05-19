namespace CP
{
    using System.Data.Entity;

    public partial class AviaDatabase : DbContext
    {
        public AviaDatabase()
            : base("name=AviaDatabase")
        {
        }

        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Plane> Plane { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
