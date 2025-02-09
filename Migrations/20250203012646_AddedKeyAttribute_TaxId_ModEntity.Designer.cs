﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserDB_API_NET.Models;

#nullable disable

namespace UserDB_API_NET.Migrations
{
    [DbContext(typeof(TestUserDataContext))]
    [Migration("20250203012646_AddedKeyAttribute_TaxId_ModEntity")]
    partial class AddedKeyAttribute_TaxId_ModEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("UserDB_API_NET.Models.User", b =>
                {
                    b.Property<long>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("TaxID");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("TaxId");

                    b.HasIndex(new[] { "Email" }, "IX_Email");

                    b.HasIndex(new[] { "PassNumber" }, "IX_PassNumber");

                    b.HasIndex(new[] { "TaxId" }, "IX_TaxID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
