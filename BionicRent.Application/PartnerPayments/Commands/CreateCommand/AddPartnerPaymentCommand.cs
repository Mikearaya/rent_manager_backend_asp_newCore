using System;
using System.Collections.Generic;
using BionicRent.Application.CustomerPayments.Models;
/*
 * @CreateTime: Jun 28, 2019 2:59 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 28, 2019 3:04 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicRent.Application.PartnerPayments.Commands.CreateCommand {
    public class AddPartnerPaymentCommand : IRequest {
        public uint PartnerId { get; set; }
        public DateTime Date { get; set; }
        public IList<RentPaymentModel> Rents = new List<RentPaymentModel> ();
    }
}