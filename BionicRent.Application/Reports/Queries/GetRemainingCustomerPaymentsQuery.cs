/*
 * @CreateTime: Jun 29, 2019 11:44 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:04 PM
 * @Description: Modify Here, Please  
 */

using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Reports.Queries {
    public class GetRemainingCustomerPaymentsQuery : ApiQueryString, IRequest<FilterResultModel<RemainingCustomerPaymentsModel>> {

    }
}