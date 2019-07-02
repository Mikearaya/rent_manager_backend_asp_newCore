using System;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Persistence {
    public class BionicRentDatabaseService : DbContext, IBionicRentDatabaseService {

        public BionicRentDatabaseService () { }
        public BionicRentDatabaseService (DbContextOptions<BionicRentDatabaseService> options) : base (options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<RentPayment> RentPayment { get; set; }
        public DbSet<RentPaymentDetail> RentPaymentDetail { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<RentCondition> VehicleCondition { get; set; }
        public DbSet<VehicleOwner> VehicleOwner { get; set; }
        public DbSet<SystemLookup> SystemLookup { get; set; }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=bionic_car_rent;");
            }

        }

        protected override void OnModelCreating (ModelBuilder builder) {

            builder.ApplyConfigurationsFromAssembly (typeof (BionicRentDatabaseService).Assembly);

        }

    }
}