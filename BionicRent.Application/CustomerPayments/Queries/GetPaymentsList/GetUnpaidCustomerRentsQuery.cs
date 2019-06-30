/*
 * @CreateTime: Jun 30, 2019 11:04 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 11:24 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicRent.Application.CustomerPayments.Models;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Queries.GetPaymentsList {
    public class GetUnpaidCustomerRentsQuery : IRequest<IEnumerable<UnpaidCustomerRentModel>> {
        public uint CustomerId { get; set; }

    }
}