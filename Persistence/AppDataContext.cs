using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;
public class AppDataContext: DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options): base(options)
    { }

    public  DbSet<Merchant> Merchants { get; set; }
    public  DbSet<Customer> Customers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<CustomerReview> Reviews { get; set; }
    public DbSet<ReviewReply> ReviewReplies { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<TemplateDefault> TemplateDefaults { get; set; }
    public DbSet<ShipingDetails> ShipingDetails { get; set; }
    public DbSet<CreditCardDetail> CreditCardDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Merchant>( m => {
            m.ToTable("Users");
            m.Property( m => m.Id)
            .HasColumnName("UserId");
            m.HasKey(m => m.Id);
            m.HasDiscriminator(m => m.UserType);
        });
        modelBuilder.Entity<Customer>();
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


        modelBuilder.Entity<Purchase>( 
            entity =>
            {
            entity.HasKey(d => new { d.CustomerId, d.DatePurchased });

            entity.HasOne<Product>(d => d.Product)
            .WithMany(p => p.Purchases)
            .HasForeignKey(o => o.ProductId);

            entity.HasOne<Order>()
            .WithMany( o => o.Purchases)
            .HasForeignKey(o => o.CustomerId);

            }
        );

        modelBuilder.Entity<CustomerReview>(
            entity => {
                entity.HasKey(r => r.ReviewId);

                entity.HasOne<Product>(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

                entity.HasOne<Customer>(r => r.Customer)
                .WithMany(c => c.ProductReviews)
                .HasForeignKey(r => r.CustomerId);
            }
        );

        modelBuilder.Entity<ReviewReply>(
            entity => {
                entity.HasKey(rr => new {rr.MerchantId, rr.ReviewId});
                
                entity.HasOne<Merchant>(rr => rr.Merchant)
                .WithMany(r => r.ReviewReplies)
                .HasForeignKey( rr => rr.MerchantId);
            }
        );

        modelBuilder.Entity<ShipingDetails>(entity =>
        {
            entity.HasKey(s => new { s.StoreId, s.CustomerId });
        });

        modelBuilder.Entity<CreditCardDetail>(entity =>
        {
            entity.HasKey(s => new { s.StoreId, s.CustomerId });
        });

        modelBuilder.Entity<TemplateDefault>(entity =>
        {
            entity.HasKey(s => s.TemplateDefaultId);
        });

    }

}
