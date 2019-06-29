/*
 * @CreateTime: Jun 9, 2019 5:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 5:57 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.UpdateVehicle {
    public class UpdateVehicleCommand : IRequest {

        public uint Id { get; set; }
        public uint? OwnerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string YearMade { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string ChassisNumber { get; set; }
        public string MotorNumber { get; set; }
        public string FuielType { get; set; }
        public string Cc { get; set; }
        public sbyte TotalPassanger { get; set; }
        public int? CylinderCount { get; set; }
        public string LibreNo { get; set; }
        public string PlateCode { get; set; }
        public string PlateNumber { get; set; }
        public string Transmission { get; set; }
    }
}