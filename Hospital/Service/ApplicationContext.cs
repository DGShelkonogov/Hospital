using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using Annotation = System.ComponentModel.DataAnnotations;

namespace Hospital.Service
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorType> DoctorTypes { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<User> Users { get; set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Hospital;Username=postgres;Password=333");
        }

        public static bool validData(Object args)
        {
            var results = new List<Annotation.ValidationResult>();
            var context = new ValidationContext(args);
            if (!Validator.TryValidateObject(args, context, results, true))
            {
                string message = "";
                foreach (var error in results)
                {
                    message += error.ErrorMessage + '\n';
                }
                MessageBox.Show(message);
                return false;
            }
            return true;
        }
    }
}
