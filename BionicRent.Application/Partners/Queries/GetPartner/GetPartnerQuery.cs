/*
 * @CreateTime: Jun 8, 2019 6:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:44 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Partners.Models;
using MediatR;

namespace BionicRent.Application.Partners.Queries.GetPartner {
    public class GetPartnerQuery : IRequest<PartnerViewModel> {
        public uint Id { get; set; }
    }
}