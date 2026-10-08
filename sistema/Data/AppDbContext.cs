using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using sistema.Models;

namespace sistema.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
            
        }
        public DbSet <Usuario> Usuarios => Set<Usuario>();
        public DbSet <Tutor> Tutores => Set<Tutor>();
        public DbSet <Pet> Pets => Set<Pet>();
        public DbSet <Agendamento> Agendamentos => Set<Agendamento>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Tutor)
            .WithMany(t => t.Pets)
            .HasForeignKey(p => p.TutorId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Agendamento>()
            .HasOne(a => a.Tutor)
            .WithMany(t => t.Agendamentos)
            .HasForeignKey(a => a.TutorId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Agendamento>()
            .HasOne(a => a.Pet)
            .WithMany(p => p.Agendamentos)
            .HasForeignKey(a => a.PetId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}