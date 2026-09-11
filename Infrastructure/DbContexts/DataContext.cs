using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TechnicalTasks.Domain.Entities;

namespace TechnicalTask.Infrastructure.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //налаштування зв'язку між ConferenceRoom та Booking
            modelBuilder.Entity<ConferenceRoom>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.ConferenceRoom)
                .HasForeignKey(b => b.RoomId);

            //налаштування зв'язку між Service та Booking
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.SelectedServices)
                .WithMany(s => s.Bookings);

            //налаштування зв'язку між Service та ConferenceRoom
            modelBuilder.Entity<ConferenceRoom>()
                .HasMany(r => r.Services)
                .WithMany(s => s.ConferenceRooms);
        }
    }
}