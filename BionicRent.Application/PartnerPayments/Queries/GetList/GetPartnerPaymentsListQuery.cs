/*
 * @CreateTime: Jun 29, 2019 5:04 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 5:05 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.Models;
using BionicRent.Application.PartnerPayments.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.PartnerPayments.Queries.GetList {
    public class GetPartnerPaymentsListQuery : ApiQueryString, IRequest<FilterResultModel<PartnerPaymentListModel>> {

    }
}