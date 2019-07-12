/*
 * @CreateTime: Jul 10, 2019 4:00 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 10, 2019 4:03 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicRent.Application.Dashboard.Models;
using BionicRent.Application.Dashboard.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.Dashboard {
    [Route ("api")]
    public class DashBoardController : Controller {
        private readonly IMediator _Mediator;

        public DashBoardController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardViewModel>> GetDashBoardView () {
            var result = await _Mediator.Send (new GetDashBoardViewQuery ());
            return StatusCode (200, result);
        }
    }
}