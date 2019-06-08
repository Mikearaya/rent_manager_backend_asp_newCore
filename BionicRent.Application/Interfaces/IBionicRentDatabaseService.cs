/*
 * @CreateTime: Jun 7, 2019 7:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:17 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.interfaces {
    public interface IBionicRentDatabaseService {
        DbSet<Customer> Customer { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<ExtendedRent> ExtendedRent { get; set; }
        DbSet<Rent> Rent { get; set; }
        DbSet<RentPayment> RentPayment { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<VehicleCondition> VehicleCondition { get; set; }
        DbSet<VehicleOwner> VehicleOwner { get; set; }
        void Save ();
        Task SaveAsync ();

    }
}