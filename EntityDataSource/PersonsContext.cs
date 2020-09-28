using assessment_server_side.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.EntityDataSource
{
    public partial class PersonsContext : DbContext, IPersonsContext
    {
        public PersonsContext()
        {
            
        }
        public PersonsContext(DbContextOptions<PersonsContext> options)
          : base(options)
        {
            
            
        }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Assescor;Integrated Security=True;Pooling=False");
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.FavColourId).HasColumnName("Fav_colour_id");

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FavColour)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FavColourId)
                    .HasConstraintName("FK_Person_Color");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
