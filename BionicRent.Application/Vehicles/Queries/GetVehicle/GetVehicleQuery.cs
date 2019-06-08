/*
 * @CreateTime: Jun 8, 2019 7:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:40 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Vehicles.Models;
using MediatR;

namespace BionicRent.Application.Vehicles.Queries.GetVehicle {
    public class GetVehicleQuery : IRequest<VehicleViewModel> {
        public uint Id { get; set; }
    }
}