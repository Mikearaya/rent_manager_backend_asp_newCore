/*
 * @CreateTime: Jun 8, 2019 7:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:09 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.CreateVehicle {
    public class CreateVehicleCommand : IRequest<uint> {
        public uint OwnerId { get; set; }
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
        public int CylinderCount { get; set; }
        public string LibreNo { get; set; }
        public string PlateCode { get; set; }
        public string PlateNumber { get; set; }
        public string Transmission { get; set; }
    }
}