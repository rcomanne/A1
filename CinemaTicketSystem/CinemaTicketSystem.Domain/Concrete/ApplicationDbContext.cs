using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace CinemaTicketSystem.Domain.Concrete
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Showing> Showings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<OrderSeat> OrderSeats { get; set; }
        public virtual DbSet<NewsletterSignup> NewsletterSignups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
