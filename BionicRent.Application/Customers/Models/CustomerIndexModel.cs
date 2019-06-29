using System;
using System.Linq.Expressions;
using BionicRent.Domain;
/*
 * @CreateTime: Jun 26, 2019 7:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 26, 2019 7:49 PM
 * @Description: Modify Here, Please 
 */
namespace BionicRent.Application.Customers.Models {
    public class CustomerIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Customer, CustomerIndexModel>> Projection {
            get {
                return customer => new CustomerIndexModel () {
                    Id = customer.CustomerId,
                    Name = customer.CustomerName
                };
            }
        }
    }
}