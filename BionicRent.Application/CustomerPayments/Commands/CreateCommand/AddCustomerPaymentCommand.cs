/*
 * @CreateTime: Jun 28, 2019 2:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 28, 2019 2:43 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicRent.Application.CustomerPayments.Models;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Commands.CreateCommand {
    public class AddCustomerPaymentCommand : IRequest {
        public uint CustomerId { get; set; }
        public DateTime Date { get; set; }
        public IList<RentPaymentModel> Rents { get; set; } = new List<RentPaymentModel> ();
    }
}