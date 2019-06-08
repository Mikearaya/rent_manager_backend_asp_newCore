using System;
/*
 * @CreateTime: Jun 8, 2019 4:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:19 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Customers.Commands.CreateCustomer {
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, uint> {
        private readonly IBionicRentDatabaseService _database;

        public CreateCustomerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (CreateCustomerCommand request, CancellationToken cancellationToken) {
            Customer customer = new Customer () {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MobileNumber = request.MobileNumber,
                OtherPhone = request.OtherPhone,
                HotelName = request.HotelName,
                HotelPhone = request.HotelPhone,
                DrivingLicenceId = request.DrivingLicenceId,
                Nationality = request.Nationality,
                City = request.City,
                Country = request.Country,
                HouseNo = request.HouseNo,
                PassportNumber = request.PassportNumber,
                RegisteredOn = DateTime.Now
            };
            _database.Customer.Add (customer);

            await _database.SaveAsync ();

            return customer.CustomerId;
        }
    }
}