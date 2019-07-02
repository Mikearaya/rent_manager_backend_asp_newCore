/*
 * @CreateTime: May 6, 2019 11:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:36 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommand : IRequest {
        public int Id { get; set; }
    }
}