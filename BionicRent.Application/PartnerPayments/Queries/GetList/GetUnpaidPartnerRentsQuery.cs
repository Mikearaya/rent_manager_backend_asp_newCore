/*
 * @CreateTime: Jun 30, 2019 5:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 5:56 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicRent.Application.PartnerPayments.Models;
using MediatR;

namespace BionicRent.Application.PartnerPayments.Queries.GetList {
    public class GetUnpaidPartnerRentsQuery : IRequest<IEnumerable<UnpaidPartnerRentModel>> {
        public uint PartnerId { get; set; }
    }
}