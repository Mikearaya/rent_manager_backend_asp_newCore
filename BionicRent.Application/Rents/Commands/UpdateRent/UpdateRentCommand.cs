/*
 * @CreateTime: Jun 10, 2019 8:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 28, 2019 9:49 AM
 * @Description: Modify Here, Please 
 */
using System;
using BionicRent.Application.Rents.Models;
using MediatR;

namespace BionicRent.Application.Rents.Commands.UpdateRent {
    public class UpdateRentCommand : IRequest {
        public uint Id { get; set; }
        public uint VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public uint CustomerId { get; set; }
        public int OwnerRentingPrice { get; set; }
        public int RentedPrice { get; set; }
        public int ColateralDeposit { get; set; }
        public uint? RentedBy { get; set; }

        public VehicleConditionModel VehicleCondition { get; set; }

    }
}