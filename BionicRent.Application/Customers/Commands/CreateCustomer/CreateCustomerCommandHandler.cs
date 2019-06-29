using System;
/*
 * @CreateTime: Jun 8, 2019 4:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 5:56 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Customers.Commands.CreateCustomer {
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, uint> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public CreateCustomerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
            var config = new MapperConfiguration (cfg => {
                cfg.CreateMap<CreateCustomerCommand, Customer> ();
            });
            _Mapper = config.CreateMapper ();
        }

        public async Task<uint> Handle (CreateCustomerCommand request, CancellationToken cancellationToken) {

            Customer customer = _Mapper.Map<CreateCustomerCommand, Customer> (request);
            customer.DateAdded = DateTime.Now;

            _database.Customer.Add (customer);

            await _database.SaveAsync ();

            return customer.CustomerId;
        }
    }
}