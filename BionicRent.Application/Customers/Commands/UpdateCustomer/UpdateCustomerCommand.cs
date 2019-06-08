/*
 * @CreateTime: Jun 8, 2019 4:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:21 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicRent.Application.Customers.Commands.UpdateCustomer {
    public class UpdateCustomerCommand : IRequest {

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string MobileNumber { get; set; }
        public string OtherPhone { get; set; }
        public string DrivingLicenceId { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
    }
}