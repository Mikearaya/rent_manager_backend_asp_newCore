/*
 * @CreateTime: Jun 10, 2019 8:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 10, 2019 8:57 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Models;
using BionicRent.Application.Rents.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Rents.Queries.GetRentsList {
    public class GetRentsListQuery : ApiQueryString, IRequest<FilterResultModel<RentListViewModel>> {

    }
}