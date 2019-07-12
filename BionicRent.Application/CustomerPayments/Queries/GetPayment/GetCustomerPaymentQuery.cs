/*
 * @CreateTime: Jul 11, 2019 4:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jul 11, 2019 4:09 PM 
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.CustomerPayments.Models;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Queries.GetPayment {
    public class GetCustomerPaymentQuery : IRequest<CustomerPaymentDetailModel> {
        public uint Id { get; set; }
    }
}