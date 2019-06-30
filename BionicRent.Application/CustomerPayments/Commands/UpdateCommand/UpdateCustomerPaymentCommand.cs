/*
 * @CreateTime: Jun 29, 2019 4:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:11 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicRent.Application.CustomerPayments.Models;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Commands.UpdateCommand {
    public class UpdateCustomerPaymentCommand : IRequest {
        public uint Id { get; set; }
        public uint CustomerId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<RentPaymentModel> Rents = new List<RentPaymentModel> ();
        public IEnumerable<uint> DeletedIds { get; set; } = new List<uint> ();
    }
}