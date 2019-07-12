/*
 * @CreateTime: Jul 10, 2019 9:20 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 10, 2019 9:21 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.Rents.Models;
using MediatR;

namespace BionicRent.Application.Rents.Queries.GetRent {
    public class GetRentContractQuery : IRequest<RentContractView> {
        public uint Id { get; set; }
    }
}