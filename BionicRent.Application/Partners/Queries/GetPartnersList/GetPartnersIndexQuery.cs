/*
 * @CreateTime: Jun 22, 2019 5:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 22, 2019 6:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Partners.Models;
using MediatR;

namespace BionicRent.Application.Partners.Queries.GetPartnersList {
    public class GetPartnersIndexQuery : IRequest<IEnumerable<PartnersIndexModel>> {
        public string Name { get; set; } = "";
    }
}