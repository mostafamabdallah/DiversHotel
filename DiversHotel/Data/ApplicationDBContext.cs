using DiversHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {

        }
        public DbSet<MealPlans> MealPlans { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}
