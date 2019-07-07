using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using BionicRent.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Persistence {
    public class BionicRentDatabaseService : IdentityDbContext<ApplicationUser, ApplicationRole, string, UserClaims, UserRoles, UserLogins, RoleClaims, UserTokens>, IBionicRentDatabaseService {

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
        public new DbSet<RoleClaims> RoleClaims { get; set; }
        public new DbSet<ApplicationRole> Roles { get; set; }
        public new DbSet<UserClaims> UserClaims { get; set; }
        public new DbSet<UserLogins> UserLogins { get; set; }
        public new DbSet<UserRoles> UserRoles { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }
        public new DbSet<UserTokens> UserTokens { get; set; }
        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=bionic_car_ress;");
            }

        }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);
            builder.ApplyConfigurationsFromAssembly (typeof (BionicRentDatabaseService).Assembly);

        }

    }
}