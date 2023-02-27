﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS_MVCDTO.Context;

#nullable disable

namespace SMSMVCDTO.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AttendantId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<int>("SalesManagerId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .HasColumnType("longtext");

                    b.Property<int>("SuperAdminId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttendantId")
                        .IsUnique();

                    b.HasIndex("SalesManagerId")
                        .IsUnique();

                    b.HasIndex("SuperAdminId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Attendant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CVPath")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorPhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SalesManagerID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalesManagerID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Attendants");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.AttendantCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AttendantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AttendantId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AttendantCustomer");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.BankDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<int>("AttendantId")
                        .HasColumnType("int");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("BankName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SalesManagerId")
                        .HasColumnType("int");

                    b.Property<int>("SuperAdminId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttendantId")
                        .IsUnique();

                    b.HasIndex("SalesManagerId")
                        .IsUnique();

                    b.HasIndex("SuperAdminId")
                        .IsUnique();

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("TransactionId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Barcode")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PicturPath")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<double>("ReorderLevel")
                        .HasColumnType("double");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SalesManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CVPath")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorPhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SalesManagers");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SuperAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SuperAdmins");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("double");

                    b.Property<int>("AttendantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReferenceNo")
                        .HasColumnType("longtext");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AttendantId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("StaffId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Credit")
                        .HasColumnType("double");

                    b.Property<double>("Debit")
                        .HasColumnType("double");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Address", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Attendant", "Attendant")
                        .WithOne("Address")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Address", "AttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.SalesManager", "SalesManager")
                        .WithOne("Address")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Address", "SalesManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.SuperAdmin", "SuperAdmin")
                        .WithOne("Address")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Address", "SuperAdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendant");

                    b.Navigation("SalesManager");

                    b.Navigation("SuperAdmin");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Attendant", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.SalesManager", "SalesManager")
                        .WithMany("Attendants")
                        .HasForeignKey("SalesManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("Attendant")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Attendant", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesManager");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.AttendantCustomer", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Attendant", "Attendant")
                        .WithMany("AttendantCustomers")
                        .HasForeignKey("AttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.Customer", "Customer")
                        .WithMany("AttendantCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendant");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.BankDetail", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Attendant", "Attendant")
                        .WithOne("BankDetail")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.BankDetail", "AttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.SalesManager", "SalesManager")
                        .WithOne("BankDetail")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.BankDetail", "SalesManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.SuperAdmin", "SuperAdmin")
                        .WithOne("BankDetail")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.BankDetail", "SuperAdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendant");

                    b.Navigation("SalesManager");

                    b.Navigation("SuperAdmin");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Cart", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.Product", "Product")
                        .WithOne("Cart")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Cart", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.Transaction", "Transaction")
                        .WithMany("Carts")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Customer", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Product", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SalesManager", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("SalesManager")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.SalesManager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SuperAdmin", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("SuperAdmin")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.SuperAdmin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Transaction", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Attendant", "Attendant")
                        .WithMany("Transaction")
                        .HasForeignKey("AttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS_MVCDTO.Models.Entities.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendant");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.User", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Attendant", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("AttendantCustomers");

                    b.Navigation("BankDetail");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Customer", b =>
                {
                    b.Navigation("AttendantCustomers");

                    b.Navigation("Carts");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Product", b =>
                {
                    b.Navigation("Cart");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SalesManager", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Attendants");

                    b.Navigation("BankDetail");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SuperAdmin", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("BankDetail");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Transaction", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.User", b =>
                {
                    b.Navigation("Attendant");

                    b.Navigation("Customer");

                    b.Navigation("SalesManager");

                    b.Navigation("SuperAdmin");
                });
#pragma warning restore 612, 618
        }
    }
}
