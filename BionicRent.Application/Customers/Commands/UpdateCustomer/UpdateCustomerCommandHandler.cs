/*
 * @CreateTime: Jun 8, 2019 4:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:37 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.Customers.Commands.UpdateCustomer {
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public UpdateCustomerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateCustomerCommand request, CancellationToken cancellationToken) {
            var customer = await _database.Customer.FindAsync (request.Id);

            if (customer == null) {
                throw new NotFoundException ($"Customer with id: {request.Id}  Not Found");
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.HotelName = request.HotelName;
            customer.HotelPhone = request.HotelPhone;
            customer.HouseNo = request.HouseNo;
            customer.MobileNumber = request.MobileNumber;
            customer.OtherPhone = request.OtherPhone;
            customer.Nationality = request.Nationality;
            customer.PassportNumber = request.PassportNumber;
            customer.City = request.City;
            customer.Country = request.Country;
            customer.DrivingLicenceId = request.DrivingLicenceId;

            _database.Customer.Update (customer);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}