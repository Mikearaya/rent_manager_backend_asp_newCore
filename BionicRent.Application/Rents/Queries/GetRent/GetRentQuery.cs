/*
 * @CreateTime: Jun 10, 2019 8:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 10, 2019 8:42 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Rents.Models;
using MediatR;

namespace BionicRent.Application.Rents.Queries.GetRent {
    public class GetRentQuery : IRequest<RentViewModel> {
        public uint Id { get; set; }
    }
}