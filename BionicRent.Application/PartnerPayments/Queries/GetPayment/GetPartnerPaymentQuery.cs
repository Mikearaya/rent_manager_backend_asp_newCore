/*
 * @CreateTime: Jul 11, 2019 6:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jul 11, 2019 6:02 PM 
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.PartnerPayments.Models;
using MediatR;

namespace BionicRent.Application.PartnerPayments.Queries.GetPayment {
    public class GetPartnerPaymentQuery : IRequest<PartnerPaymentDetailModel> {
        public uint Id { get; set; }
    }
}