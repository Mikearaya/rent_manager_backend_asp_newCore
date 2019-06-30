/*
 * @CreateTime: Jun 29, 2019 4:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:40 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Queries.GetPaymentsList {
    public class GetCustomerPaymentsListQuery : ApiQueryString, IRequest<FilterResultModel<CustomerPaymentListModel>> {

    }
}