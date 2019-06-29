/*
 * @CreateTime: Jun 29, 2019 12:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:30 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.PartnerPayments.Commands.CreateCommand;
using BionicRent.Application.PartnerPayments.Models;
using BionicRent.Application.PartnerPayments.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.PartnerPayments {
    [Route ("partners/payments")]
    public class PartnerPaymentsController : Controller {
        private readonly IMediator _Mediator;

        public PartnerPaymentsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<RemainingPartnerPaymentsModel>>> GetRemainingCustomerPayments ([FromBody] GetRemainingPartnerPaymentsQuery query) {
            var remainingPayments = await _Mediator.Send (query);
            return Ok (remainingPayments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewCustomerPayment ([FromBody] AddPartnerPaymentCommand command) {
            await _Mediator.Send (command);
            return StatusCode (201);
        }

    }
}