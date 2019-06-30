/*
 * @CreateTime: Jun 29, 2019 11:57 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 11:26 AMM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicRent.Application.CustomerPayments.Commands.CreateCommand;
using BionicRent.Application.CustomerPayments.Commands.DeleteCommand;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.CustomerPayments.Queries.GetPaymentsList;
using BionicRent.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.CustomerPayments {

    [Route ("api/customer-payments")]
    public class CustomerPaymentsController : Controller {
        private readonly IMediator _Mediator;

        public CustomerPaymentsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("unpaid/{customerId}")]
        public async Task<ActionResult<IEnumerable<UnpaidCustomerRentModel>>> GetUnpaidCustomerPaymnets (uint customerId) {
            var result = await _Mediator.Send (new GetUnpaidCustomerRentsQuery () { CustomerId = customerId });
            return Ok (result);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<CustomerPaymentListModel>>> GetRemainingCustomerPayments ([FromBody] GetCustomerPaymentsListQuery query) {
            var remainingPayments = await _Mediator.Send (query);
            return Ok (remainingPayments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewCustomerPayment ([FromBody] AddCustomerPaymentCommand command) {
            await _Mediator.Send (command);
            return StatusCode (201);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteCustomerPayment (uint id) {
            await _Mediator.Send (new DeleteCustomerPaymentCommand () { Id = id });
            return NoContent ();
        }
    }
}