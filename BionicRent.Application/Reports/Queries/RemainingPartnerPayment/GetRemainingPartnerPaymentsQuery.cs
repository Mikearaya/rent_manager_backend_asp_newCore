/*
 * @CreateTime: Jun 28, 2019 3:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:02 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Reports.Queries {
    public class GetRemainingPartnerPaymentsQuery : ApiQueryString, IRequest<FilterResultModel<RemainingPartnerPaymentsModel>> {

    }
}