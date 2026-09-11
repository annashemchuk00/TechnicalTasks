using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TechnicalTasks.Domain.Entities;

namespace TechnicalTasks.Infrastructure.SeedData
{
    public static class Data 
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConferenceRoom>().HasData(
                new ConferenceRoom
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Зал А",
                    Capacity = 50,
                    BasePricePerHour = 2000
                },
                new ConferenceRoom
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Зал В",
                    Capacity = 100,
                    BasePricePerHour = 3500
                },
                new ConferenceRoom
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Зал С",
                    Capacity = 30,
                    BasePricePerHour = 1500
                });

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Проєктор",
                    Price = 500
                },
                new Service
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Wi-Fi",
                    Price = 300
                },
                new Service
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    Name = "Звук",
                    Price = 700
                });
        }
    }
}
