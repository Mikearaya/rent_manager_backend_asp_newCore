/*
 * @CreateTime: Jun 8, 2019 7:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:31 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.DeleteVehicle {
    public class DeleteVehicleCommand : IRequest {
        public uint Id { get; set; }
    }
}