/*
 * @CreateTime: Jun 29, 2019 4:59 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jun 29, 2019 4:59 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicRent.Application.PartnerPayments.Commands.DeleteCommand {
    public class DeletePartnerPaymentCommand : IRequest {
        public uint Id { get; set; }
    }
}