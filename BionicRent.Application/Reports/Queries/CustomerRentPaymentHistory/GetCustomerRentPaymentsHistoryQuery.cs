/*
 * @CreateTime: Jul 11, 2019 2:52 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 2:58 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Reports.Queries {
    public class GetCustomerRentPaymentsHistoryQuery : ApiQueryString, IRequest<FilterResultModel<CustomerRentPaymentHistoryModel>> {

    }
}