/*
 * @CreateTime: Jun 30, 2019 6:27 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 3:23 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Application.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.Reports {

    [Route ("api/reports")]
    public class ReportsController : Controller {
        private readonly IMediator _Mediator;

        public ReportsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("remaining-partner-payments")]
        public async Task<ActionResult<FilterResultModel<RemainingPartnerPaymentsModel>>> GetRemainingPartnerPayments ([FromBody] GetRemainingPartnerPaymentsQuery query) {
            var remainingPartnerPayments = await _Mediator.Send (query);
            return Ok (remainingPartnerPayments);
        }

        [HttpPost ("remaining-customer-payments")]
        public async Task<ActionResult<FilterResultModel<RemainingCustomerPaymentsModel>>> GetRemainingCustomerPayments ([FromBody] GetRemainingCustomerPaymentsQuery query) {
            var remainingCustomerPayments = await _Mediator.Send (query);
            return Ok (remainingCustomerPayments);
        }

        [HttpPost ("rent-history")]
        public async Task<ActionResult<FilterResultModel<RentHistoryModel>>> GetRentHistory ([FromBody] GetRentHistoryQuery query) {
            var history = await _Mediator.Send (query);
            return Ok (history);
        }

    }

}