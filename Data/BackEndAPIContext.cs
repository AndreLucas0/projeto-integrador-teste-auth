using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class BackEndAPIContext : DbContext
    {
        public DbSet<api.Models.LegalEntity> LegalEntity { get; set; } = default!;
        public DbSet<api.Models.NaturalPerson> NaturalPerson { get; set; } = default!;
        public DbSet<api.Models.Phone> Phone { get; set; } = default!;
        public DbSet<api.Models.Email> Email { get; set; } = default!;
        public DbSet<api.Models.Address> Address { get; set; } = default!;
        public DbSet<api.Models.User> User { get; set; } = default!;
        // public DbSet<api.Models.Dealership> Dealership { get; set; } = default!;

        public BackEndAPIContext (DbContextOptions<BackEndAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<LegalEntity>().ToTable("LegalEntity");
            modelBuilder.Entity<NaturalPerson>().ToTable("NaturalPerson");


            modelBuilder.Entity<Client>()
                .HasMany(c => c.Phones)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Emails)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Dealership>()
            //     .HasOne(d => d.Address)
            //     .WithOne(a => a.Dealership)
            //     .HasForeignKey<Dealership>(d => d.AddressId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
