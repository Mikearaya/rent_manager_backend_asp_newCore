/*
 * @CreateTime: Jun 8, 2019 6:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:18 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Partners.Commands.CreatePartner {
    public class CreatePartnerCommand : IRequest<uint> {

        public string PartnerName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Wereda { get; set; }
        public string HouseNumber { get; set; }

    }
}