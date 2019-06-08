/*
 * @CreateTime: Jun 8, 2019 6:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:49 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Models;
using BionicRent.Application.Partners.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Partners.Queries.GetPartnersList {
    public class GetPartnersListQuery : ApiQueryString, IRequest<FilterResultModel<PartnerViewModel>> {

    }
}