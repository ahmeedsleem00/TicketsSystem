using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;
using TicketSystemTask;
using TicketSystemTask.Repository.Data;



namespace TicketSystemTask.Repository
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
           .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                        .HasOne(u => u.Ticket)
                        .WithOne(u => u.User)
                        .HasForeignKey<Ticket>(u => u.UserId);

            modelBuilder.Entity<Ticket>()
           .HasKey(t => t.Id);

            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
