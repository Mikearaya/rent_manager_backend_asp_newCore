/*
 * @CreateTime: Jun 29, 2019 4:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:55 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicRent.Application.CustomerPayments.Models;
using MediatR;

namespace BionicRent.Application.PartnerPayments.Commands.UpdateCommand {
    public class UpdatePartnerPaymentCommand : IRequest {
        public uint Id { get; set; }
        public uint PartnerId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<RentPaymentModel> Rents = new List<RentPaymentModel> ();
        public IEnumerable<uint> DeletedIds { get; set; } = new List<uint> ();
    }
}