﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.CustomerReview", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCommented")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("ReviewId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Merchant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("Merchant");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderState")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ProductCategory")
                        .HasColumnType("text");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid");

                    b.Property<string>("UnitOfMeasurement")
                        .HasColumnType("text");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Purchase", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DatePurchased")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("PurchaseState")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityPurchased")
                        .HasColumnType("integer");

                    b.HasKey("CustomerId", "DatePurchased");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Domain.ReviewReply", b =>
                {
                    b.Property<Guid>("MerchantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateReplied")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Reply")
                        .HasColumnType("text");

                    b.HasKey("MerchantId", "ReviewId");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.ToTable("ReviewReplies");
                });

            modelBuilder.Entity("Domain.Store", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MerchantId")
                        .HasColumnType("uuid");

                    b.Property<string>("StoreName")
                        .HasColumnType("text");

                    b.HasKey("StoreId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Domain.Template", b =>
                {
                    b.Property<Guid>("TemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BgImg")
                        .HasColumnType("text");

                    b.Property<string>("Ftext")
                        .HasColumnType("text");

                    b.Property<string>("SMedia")
                        .HasColumnType("text");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid");

                    b.Property<string>("heroSub")
                        .HasColumnType("text");

                    b.Property<string>("herotext")
                        .HasColumnType("text");

                    b.Property<string>("logo")
                        .HasColumnType("text");

                    b.Property<string>("main")
                        .HasColumnType("text");

                    b.Property<string>("sub")
                        .HasColumnType("text");

                    b.HasKey("TemplateId");

                    b.HasIndex("StoreId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Domain.Customer", b =>
                {
                    b.HasBaseType("Domain.Merchant");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Domain.CustomerReview", b =>
                {
                    b.HasOne("Domain.Customer", "Customer")
                        .WithMany("ProductReviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.HasOne("Domain.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("Domain.Store", "Store")
                        .WithMany("Inventory")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Purchase", b =>
                {
                    b.HasOne("Domain.Order", null)
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("Purchases")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.ReviewReply", b =>
                {
                    b.HasOne("Domain.Merchant", "Merchant")
                        .WithMany("ReviewReplies")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CustomerReview", "Review")
                        .WithOne("ReviewReply")
                        .HasForeignKey("Domain.ReviewReply", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Domain.Store", b =>
                {
                    b.HasOne("Domain.Merchant", "Merchant")
                        .WithMany("Stores")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Domain.Template", b =>
                {
                    b.HasOne("Domain.Store", "Store")
                        .WithMany("Template")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.CustomerReview", b =>
                {
                    b.Navigation("ReviewReply");
                });

            modelBuilder.Entity("Domain.Merchant", b =>
                {
                    b.Navigation("ReviewReplies");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Navigation("Purchases");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.Store", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Domain.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
