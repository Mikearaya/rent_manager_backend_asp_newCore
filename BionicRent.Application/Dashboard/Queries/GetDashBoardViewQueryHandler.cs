using System;
/*
 * @CreateTime: Jul 10, 2019 3:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 10, 2019 4:05 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Dashboard.Models;
using BionicRent.Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Dashboard.Queries {
    public class GetDashBoardViewQueryHandler : IRequestHandler<GetDashBoardViewQuery, DashboardViewModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetDashBoardViewQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<DashboardViewModel> Handle (GetDashBoardViewQuery request, CancellationToken cancellationToken) {
            DashboardViewModel dashboard = new DashboardViewModel ();

            dashboard.TotalCustomers = await _database.Customer.CountAsync ();
            dashboard.TotalPartners = await _database.VehicleOwner.CountAsync ();
            dashboard.TotalVehicles = await _database.Vehicle.CountAsync ();
            dashboard.TotalRent = await _database.Rent.CountAsync ();
            dashboard.ActiveRents = await _database.Rent.CountAsync (r => r.Status.ToUpper () == "RENTED");
            dashboard.OverdueRents = await _database.Rent.CountAsync (r => r.Status.ToUpper () == "RENTED" && r.ReturnDate != null && r.ReturnDate < DateTime.Now);

            return dashboard;
        }
    }
}