using System;
/*
 * @CreateTime: Jun 9, 2019 6:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 10, 2019 8:23 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicRent.Application.interfaces;
using BionicRent.Application.Rents.Models;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Rents.Commands.CreateRent {
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, uint> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public CreateRentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;

            /*      var config = new MapperConfiguration (c => {
                c.CreateMap<CreateRentCommand, Rent> ().IncludeMembers (s => s.VehicleCondition, s => s.VehicleCondition);
                c.CreateMap<VehicleConditionModel, RentCondition> (MemberList.None);
            });

            _Mapper = config.CreateMapper ();
 */
        }

        public async Task<uint> Handle (CreateRentCommand request, CancellationToken cancellationToken) {

            Rent rent = new Rent () {
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                CustomerId = request.CustomerId,
                VehicleId = request.VehicleId,

                RentedPrice = request.RentedPrice,
                StartDate = request.StartDate,
                ReturnDate = request.ReturnDate,
                OwnerRentingPrice = request.OwnerRentingPrice,
                ColateralDeposit = request.ColateralDeposit,
                RentCondition = new List<RentCondition> () {
                new RentCondition () {
                WindowController = request.VehicleCondition.WindowController,
                SeatBelt = request.VehicleCondition.SeatBelt,
                SpareTire = request.VehicleCondition.SpareTire,
                Wiper = request.VehicleCondition.Wiper,
                CrickWrench = request.VehicleCondition.CrickWrench,
                DashboardClose = request.VehicleCondition.DashboardClose,
                MudeProtecter = request.VehicleCondition.MudeProtecter,
                SpokioOuter = request.VehicleCondition.SpokioInner,
                SpokioInner = request.VehicleCondition.SpokioOuter,
                SunVisor = request.VehicleCondition.SunVisor,
                MatInner = request.VehicleCondition.MatInner,
                WindProtecter = request.VehicleCondition.WindProtecter,
                Blinker = request.VehicleCondition.Blinker,
                Radio = request.VehicleCondition.Radio,
                FuielLevel = request.VehicleCondition.FuielLevel,
                CigaretLighter = request.VehicleCondition.CigaretLighter,
                FuielLid = request.VehicleCondition.FuielLid,
                RadiatorLid = request.VehicleCondition.RadiatorLid,
                Crick = request.VehicleCondition.Crick,
                Comment = request.VehicleCondition.Comment,
                TotalKilometer = request.VehicleCondition.TotalKilometer
                }
                }
            };

            _database.Rent.Add (rent);
            await _database.SaveAsync ();

            return await Task.FromResult<uint> (rent.RentId);

        }
    }
}