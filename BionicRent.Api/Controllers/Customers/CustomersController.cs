using System.Threading.Tasks;
using BionicRent.Application.Customers.Commands.CreateCustomer;
using BionicRent.Application.Customers.Commands.DeleteCustomer;
using BionicRent.Application.Customers.Commands.UpdateCustomer;
using BionicRent.Application.Customers.Models;
using BionicRent.Application.Customers.Queries.GetCustomer;
using BionicRent.Application.Customers.Queries.GetCustomerList;
using BionicRent.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.Customers {
    public class CustomersController : Controller {
        private readonly IMediator _Mediator;

        public CustomersController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<CustomerViewModel>> FindCustomerById (uint id) {

            var customer = await _Mediator.Send (new GetCustomerQuery () { Id = id });
            return Ok (customer);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<CustomerViewModel>>> GetCustomersList ([FromBody] GetCustomersListQuery query) {
            var customers = await _Mediator.Send (query);
            return Ok (customers);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> CreateCustomer ([FromBody] CreateCustomerCommand command) {
            var customerId = await _Mediator.Send (command);
            var newCustomer = await _Mediator.Send (new GetCustomerQuery () { Id = customerId });
            return StatusCode (200, newCustomer);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteCustomer (uint id) {
            await _Mediator.Send (new DeleteCustomerCommand () { Id = id });
            return NoContent ();
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateCustomer ([FromBody] UpdateCustomerCommand command) {
            await _Mediator.Send (command);
            return NoContent ();
        }

    }
}