/*
 * @CreateTime: Jun 8, 2019 7:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:32 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.Vehicles.Commands.DeleteVehicle {
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand> {
        public DeleteVehicleCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}