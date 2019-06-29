/*
 * @CreateTime: Jun 10, 2019 8:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 10, 2019 8:35 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Rents.Commands.DeleteRent {
    public class DeleteRentCommand : IRequest {
        public uint Id { get; set; }
    }
}