/*
 * @CreateTime: Jun 8, 2019 7:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:23 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.Vehicles.Commands.UpdateVehicle {
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand> {
        public UpdateVehicleCommandValidator () {

            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.Make).NotNull ().NotEmpty ();
            RuleFor (x => x.Model).NotNull ().NotEmpty ();
            RuleFor (x => x.Transmission).NotNull ().NotEmpty ();
            RuleFor (x => x.Type).NotNull ().NotEmpty ();
            RuleFor (x => x.YearMade).NotNull ().NotEmpty ();    
            RuleFor (x => x.PlateCode).NotNull ().NotEmpty ();
            RuleFor (x => x.PlateNumber).NotNull ().NotEmpty ();
            RuleFor (x => x.Model).NotNull ().NotEmpty ();
            RuleFor (x => x.FuielType).NotNull ().NotEmpty ();
            RuleFor (x => x.Color).NotNull ().NotEmpty ();
            
        }
    }
}