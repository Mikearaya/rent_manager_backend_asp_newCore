/*
 * @CreateTime: Jun 8, 2019 6:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:03 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Partners.Commands.UpdatePartner {
    public class UpdatePartnerCommand : IRequest {

        public uint Id { get; set; }
        public string PartnerName { get; set; }

        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Wereda { get; set; }
        public string HouseNumber { get; set; }

    }
}