using System;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Persistence {
    public class BionicRentDatabaseService : DbContext, IBionicRentDatabaseService {

        public BionicRentDatabaseService () { }
        public BionicRentDatabaseService (DbContextOptions<BionicRentDatabaseService> options) : base (options) { }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExtendedRent> ExtendedRent { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<RentPayment> RentPayment { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleCondition> VehicleCondition { get; set; }
        public virtual DbSet<VehicleOwner> VehicleOwner { get; set; }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=car_rent;");
            }

        }

        protected override void OnModelCreating (ModelBuilder builder) {

            builder.ApplyConfigurationsFromAssembly (typeof (BionicRentDatabaseService).Assembly);

        }

    }
}