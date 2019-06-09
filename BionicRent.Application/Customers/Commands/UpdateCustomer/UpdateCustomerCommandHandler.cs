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
using AutoMapper;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Customers.Commands.UpdateCustomer {
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public UpdateCustomerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
            var config = new MapperConfiguration (c => {
                c.CreateMap<UpdateCustomerCommand, Customer> ();
            });

            _Mapper = config.CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateCustomerCommand request, CancellationToken cancellationToken) {
            var customer = await _database.Customer.FindAsync (request.Id);

            if (customer == null) {
                throw new NotFoundException ($"Customer with id: {request.Id}  Not Found");
            }

            _Mapper.Map (request, customer);

            _database.Customer.Update (customer);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}