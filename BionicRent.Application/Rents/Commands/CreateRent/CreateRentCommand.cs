/*
 * @CreateTime: Jun 9, 2019 6:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicRent.Application.Rents.Models;
using MediatR;

namespace BionicRent.Application.Rents.Commands.CreateRent {
    public class CreateRentCommand : IRequest<uint> {

        public uint VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public uint CustomerId { get; set; }
        public int OwnerRentingPrice { get; set; }
        public int RentedPrice { get; set; }
        public int ColateralDeposit { get; set; }
        public VehicleConditionModel VehicleCondition { get; set; }

    }
}