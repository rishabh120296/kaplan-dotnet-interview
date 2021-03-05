using Microsoft.EntityFrameworkCore;

namespace WebApiTest.Data
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext( DbContextOptions<TestDbContext> options )
            : base( options )
        { }

        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<OrderItem>()
                        .HasKey( o => new { o.OrderID, o.LineNumber } );

            modelBuilder.Entity<OrderItem>()
                        .Property(e => e.Price)
                        .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                        .HasMany( e => e.OrderItems )
                        .WithOne( e => e.Order )
                        .IsRequired()
                        .OnDelete( DeleteBehavior.Cascade );

            modelBuilder.Entity<Person>()
                        .HasMany( e => e.Orders )
                        .WithOne( e => e.Person )
                        .IsRequired()
                        .HasForeignKey( e => e.OrderingPersonID )
                        .OnDelete( DeleteBehavior.Cascade );

            modelBuilder.Entity<Person>()
                        .HasMany( e => e.OrderItems )
                        .WithOne( e => e.StudentPerson ).IsRequired()
                        .HasForeignKey( e => e.StudentPersonID )
                        .OnDelete( DeleteBehavior.Cascade );

            modelBuilder.Entity<Product>()
                        .Property( e => e.Name )
                        .IsUnicode( false );

            modelBuilder.Entity<Product>()
                        .Property( e => e.UnitPrice )
                        .HasPrecision( 19, 4 );

            modelBuilder.Entity<Product>()
                        .HasMany( e => e.OrderItems )
                        .WithOne( e => e.Product ).IsRequired()
                        .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
