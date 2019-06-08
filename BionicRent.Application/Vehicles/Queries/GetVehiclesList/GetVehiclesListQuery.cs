/*
 * @CreateTime: Jun 8, 2019 7:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:47 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Models;
using BionicRent.Application.Vehicles.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Vehicles.Queries.GetVehiclesList {
    public class GetVehiclesListQuery : ApiQueryString, IRequest<FilterResultModel<VehicleViewModel>> {

    }
}