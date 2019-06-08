/*
 * @CreateTime: Jun 8, 2019 4:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:32 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Customers.Commands.DeleteCustomer {
    public class DeleteCustomerCommand : IRequest {
        public uint Id { get; set; }
    }
}