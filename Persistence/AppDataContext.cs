using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;
public class AppDataContext: DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options): base(options)
    { }

    public virtual DbSet<Merchant> Merchants { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Merchant>( m => {
            m.ToTable("Users");
            m.Property( m => m.MerchantID)
            .HasColumnName("UserId");
            m.HasKey(m => m.MerchantID);
            m.HasDiscriminator(m => m.UserType);
        });
        modelBuilder.Entity<Customer>(
            entity => {
                entity.Property( c => c.CustomerId)
                .HasColumnName("MerchanID");
            }
        );
        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Store>( s => 
        {
            s.HasKey(s => s.StoreId);

            s.HasOne<Merchant>(s => s.Merchant)
            .WithMany(m => m.Stores)
            .HasForeignKey(s => s.MerchantId);

            s.HasMany<Product>(s => s.Inventory)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId);

        });


        modelBuilder.Entity<Order>( 
            o =>
            {
            o.HasKey(d => new { d.CustomerId, d.DateOrdered });

            o.HasOne<Product>(d => d.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProductId);

            o.HasOne<Customer>()
            .WithMany( o => o.Orders)
            .HasForeignKey(o => o.CustomerId);

            }
        );
    }

}
