/*
 * @CreateTime: Jun 7, 2019 7:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:19 PMM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.interfaces {
    public interface IBionicRentDatabaseService {
        DbSet<Customer> Customer { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<Rent> Rent { get; set; }
        DbSet<RentPayment> RentPayment { get; set; }
        DbSet<RentPaymentDetail> RentPaymentDetail { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<RentCondition> VehicleCondition { get; set; }
        DbSet<VehicleOwner> VehicleOwner { get; set; }
        void Save ();
        Task SaveAsync ();

    }
}