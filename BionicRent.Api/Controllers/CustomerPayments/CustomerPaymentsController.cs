/*
 * @CreateTime: Jun 29, 2019 11:57 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:30 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicRent.Application.CustomerPayments.Commands.CreateCommand;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.CustomerPayments.Queries.GetList;
using BionicRent.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.CustomerPayments {

    [Route ("customers/payments")]
    public class CustomerPaymentsController : Controller {
        private readonly IMediator _Mediator;

        public CustomerPaymentsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<RemainingCustomerPaymentsModel>>> GetRemainingCustomerPayments ([FromBody] GetRemainingCustomerPaymentsQuery query) {
            var remainingPayments = await _Mediator.Send (query);
            return Ok (remainingPayments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewCustomerPayment ([FromBody] AddCustomerPaymentCommand command) {
            await _Mediator.Send (command);
            return StatusCode (201);
        }
    }
}