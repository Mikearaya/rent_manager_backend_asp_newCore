/*
 * @CreateTime: Jun 29, 2019 11:44 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 11:45 AM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Queries.GetList {
    public class GetRemainingCustomerPaymentsQuery : ApiQueryString, IRequest<FilterResultModel<RemainingCustomerPaymentsModel>> {

    }
}