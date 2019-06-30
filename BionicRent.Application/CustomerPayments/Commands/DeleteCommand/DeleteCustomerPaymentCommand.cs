/*
 * @CreateTime: Jun 29, 2019 4:23 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jun 29, 2019 4:23 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicRent.Application.CustomerPayments.Commands.DeleteCommand {
    public class DeleteCustomerPaymentCommand : IRequest {
        public uint Id { get; set; }
    }
}