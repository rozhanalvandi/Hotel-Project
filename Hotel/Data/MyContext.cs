 using System;
using Hotel.Models.Entities.Product;
using Hotel.Models.Entities.User;
using Hotel.Models.Entities.Web;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite("Data Source=data.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvantageToRoom>().HasKey(ar => new { ar.AdvantageId, ar.RoomId });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FirstBaner> firstBaners { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Hotell> hotels { get; set; }
        public DbSet<HotelAdderss> hotelAddresses { get; set; }
        public DbSet<HotelGallery> hotelGalleries { get; set; }
        public DbSet<HotelRoom> hotelRooms { get; set; }
        public DbSet<HotelRules> hotelRules { get; set; }
        public DbSet<Reserve> reserveDates { get; set; }
        public DbSet<AdvantageRoom> advantageRooms { get; set; }
        public DbSet<AdvantageToRoom> advantageToRs { get; set; }

    }

}