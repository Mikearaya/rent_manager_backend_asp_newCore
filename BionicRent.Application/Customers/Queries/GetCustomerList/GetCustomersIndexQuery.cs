/*
 * @CreateTime: Jun 26, 2019 7:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 26, 2019 7:51 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Customers.Models;
using MediatR;

namespace BionicRent.Application.Customers.Queries.GetCustomerList {
    public class GetCustomersIndexQuery : IRequest<IEnumerable<CustomerIndexModel>> {
        public string Name { get; set; }
    }
}