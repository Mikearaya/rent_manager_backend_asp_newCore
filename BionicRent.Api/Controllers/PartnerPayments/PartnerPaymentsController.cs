/*
 * @CreateTime: Jun 29, 2019 12:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 6:01 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.PartnerPayments.Commands.CreateCommand;
using BionicRent.Application.PartnerPayments.Commands.DeleteCommand;
using BionicRent.Application.PartnerPayments.Models;
using BionicRent.Application.PartnerPayments.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.PartnerPayments {
    [Route ("api/partner-payments")]
    public class PartnerPaymentsController : Controller {
        private readonly IMediator _Mediator;

        public PartnerPaymentsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<PartnerPaymentListModel>>> GetRemainingPartnerPayment ([FromBody] GetPartnerPaymentsListQuery query) {
            var remainingPayments = await _Mediator.Send (query);
            return Ok (remainingPayments);
        }

        [HttpGet ("unpaid/{partnerId}")]
        public async Task<ActionResult<IEnumerable<UnpaidPartnerRentModel>>> GetUnpaidPartnerRents (uint partnerId) {
            var unpaidPayments = await _Mediator.Send (new GetUnpaidPartnerRentsQuery () { PartnerId = partnerId });
            return Ok (unpaidPayments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewPartnerPayment ([FromBody] AddPartnerPaymentCommand command) {
            await _Mediator.Send (command);
            return StatusCode (201);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeletePartnerPayment (uint id) {
            await _Mediator.Send (new DeletePartnerPaymentCommand () { Id = id });
            return NoContent ();
        }

    }
}