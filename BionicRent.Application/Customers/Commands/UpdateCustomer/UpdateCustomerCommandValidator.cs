/*
 * @CreateTime: Jun 8, 2019 4:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:23 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.Customers.Commands.UpdateCustomer {
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand> {
        public UpdateCustomerCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.CustomerName).NotEmpty ().NotNull ();
            RuleFor (x => x.MobileNumber).NotEmpty ().NotNull ();
            RuleFor (x => x.DrivingLicenceId).NotEmpty ().NotNull ();
        }
    }
}