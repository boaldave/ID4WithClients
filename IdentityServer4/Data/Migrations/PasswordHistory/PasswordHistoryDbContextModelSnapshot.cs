using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdentityServer.Host.Data.Migrations
{
    [DbContext(typeof(PasswordHistoryDbContext))]
    partial class PasswordHistoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);


            ///////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity("IdentityServer.Host.Models.PasswordHistory", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("userId");

                b.Property<string>("PasswordHash");

                b.HasKey("Id");

                //b.HasIndex("userId")
                //    .HasName("userId");

                b.ToTable("PasswordHistory");
            });
            ///////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
