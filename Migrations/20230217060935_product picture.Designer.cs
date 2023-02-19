﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS_MVCDTO.Context;

#nullable disable

namespace SMSMVCDTO.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230217060935_product picture")]
    partial class productpicture
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Attendant", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("BankName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomerStaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorPhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("userRole")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("CustomerStaffId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Attendants");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomermId")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ProductId")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Customer", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("userRole")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Product", b =>
                {
                    b.Property<string>("Barcode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Category")
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

                    b.Property<byte[]>("Pictur")
                        .HasColumnType("longblob");

                    b.Property<string>("ProductCategoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<double>("ReorderLevel")
                        .HasColumnType("double");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("double");

                    b.HasKey("Barcode");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.ProductCategory", b =>
                {
                    b.Property<string>("CategoryCode")
                        .HasColumnType("varchar(255)");

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

                    b.HasKey("CategoryCode");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SalesManager", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("BankName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorPhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("userRole")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SalesManagers");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SuperAdmin", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("BankName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorPhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("userRole")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SuperAdmins");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Transaction", b =>
                {
                    b.Property<string>("ReferenceNo")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("double");

                    b.Property<string>("AttendantId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CartId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double");

                    b.HasKey("ReferenceNo");

                    b.HasIndex("AttendantId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.User", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("StaffId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AttendantId")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Credit")
                        .HasColumnType("double");

                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Debit")
                        .HasColumnType("double");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AttendantId")
                        .IsUnique();

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Attendant", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Customer", null)
                        .WithMany("Attendants")
                        .HasForeignKey("CustomerStaffId");

                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("Attendant")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Attendant", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Customer", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Customer", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Product", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SalesManager", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("SalesManager")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.SalesManager", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.SuperAdmin", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.User", "User")
                        .WithOne("SuperAdmin")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.SuperAdmin", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Transaction", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Attendant", "Attendant")
                        .WithMany()
                        .HasForeignKey("AttendantId");

                    b.HasOne("SMS_MVCDTO.Models.Entities.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Attendant");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Wallet", b =>
                {
                    b.HasOne("SMS_MVCDTO.Models.Entities.Attendant", "Attendant")
                        .WithOne("Wallets")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Wallet", "AttendantId");

                    b.HasOne("SMS_MVCDTO.Models.Entities.Customer", "Customer")
                        .WithOne("Wallets")
                        .HasForeignKey("SMS_MVCDTO.Models.Entities.Wallet", "CustomerId");

                    b.Navigation("Attendant");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Attendant", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.Customer", b =>
                {
                    b.Navigation("Attendants");

                    b.Navigation("Transactions");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("SMS_MVCDTO.Models.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
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