// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestApp.Models;

namespace TestApp.Migrations
{
    [DbContext(typeof(LinkDbContext))]
    partial class LinkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("TestApp.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkLong")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkShort")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });
#pragma warning restore 612, 618
        }
    }
}