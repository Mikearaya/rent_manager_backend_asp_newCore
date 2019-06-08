/*
 * @CreateTime: Jun 8, 2019 4:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:49 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Customers.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Customers.Queries.GetCustomer {
    public class GetCustomerQuery : IRequest<CustomerViewModel> {
        public uint Id { get; set; }
    }
}