using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda2998601.Model;

namespace Asistencia.Model
{
    public class AsistenciaContext : DbContext
    {
        public DbSet<Acudiente> Acudiente { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<Presencia> Presencia { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<Grado_Asignatura> Grado_Asignatura { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acudiente>()
                .HasIndex(a => a.Documento)
                .IsUnique();

            modelBuilder.Entity<Acudiente>()
                .HasIndex(a => a.telefono)
                .IsUnique();

            modelBuilder.Entity<Acudiente>()
                .HasIndex(a => a.Correo)
                .IsUnique();

            modelBuilder.Entity<Alumno>()
                .HasIndex(a => a.Documento)
                .IsUnique();

            modelBuilder.Entity<Alumno>()
                .HasIndex(a => a.Telefono)
                .IsUnique();

            modelBuilder.Entity<Grado>()
                .HasIndex(g => g.Nombre)
                .IsUnique();

            modelBuilder.Entity<Profesor>()
                .HasIndex(p => p.Documento)
                .IsUnique();

            modelBuilder.Entity<Profesor>()
                .HasIndex(p => p.Correo)
                .IsUnique();

            modelBuilder.Entity<Presencia>()
                .HasOne(p => p.Grados)
                .WithMany()
                .HasForeignKey(p => p.GradoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presencia>()
                .HasOne(p => p.Alumnos)
                .WithMany()
                .HasForeignKey(p => p.AlumnoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presencia>()
                .HasOne(p => p.Asignaturas)
                .WithMany()
                .HasForeignKey(p => p.AsignaturaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //aca se crea la cadena de conexion 
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JTDD74O\SQLEXPRESS; Database=Asistencia; trusted_Connection=true");
        }
    }
}

