using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Rents.Models {
    public class VehicleConditionModel {
        public int? ConditionId { get; set; }
        public uint? RentId { get; set; }
        public int? WindowController { get; set; }
        public int? SeatBelt { get; set; }
        public int? SpareTire { get; set; }
        public int? Wiper { get; set; }
        public int? CrickWrench { get; set; }
        public int? DashboardClose { get; set; }
        public int? MudeProtecter { get; set; }
        public int? SpokioOuter { get; set; }
        public int? SpokioInner { get; set; }
        public int? SunVisor { get; set; }
        public int? MatInner { get; set; }
        public int? WindProtecter { get; set; }
        public int? Blinker { get; set; }
        public string Radio { get; set; }
        public string FuielLevel { get; set; }
        public int? CigaretLighter { get; set; }
        public int? FuielLid { get; set; }
        public int? RadiatorLid { get; set; }
        public int? Crick { get; set; }
        public string Comment { get; set; }
        public int? TotalKilometer { get; set; }

        public static Expression<Func<RentCondition, VehicleConditionModel>> Projection {
            get {
                return condition => new VehicleConditionModel () {
                    ConditionId = condition.ConditionId,
                    RentId = condition.RentId,
                    WindowController = condition.WindowController,
                    SeatBelt = condition.SeatBelt,
                    SpareTire = condition.SpareTire,
                    Wiper = condition.Wiper,
                    CrickWrench = condition.CrickWrench,
                    DashboardClose = condition.DashboardClose,
                    MudeProtecter = condition.MudeProtecter,
                    SpokioInner = condition.SpokioInner,
                    SpokioOuter = condition.SpokioOuter,
                    SunVisor = condition.SunVisor,
                    MatInner = condition.MatInner,
                    WindProtecter = condition.WindProtecter,
                    Blinker = condition.Blinker,
                    Radio = condition.Radio,
                    FuielLevel = condition.FuielLevel,
                    CigaretLighter = condition.CigaretLighter,
                    FuielLid = condition.FuielLid,
                    RadiatorLid = condition.RadiatorLid,
                    Crick = condition.Crick,
                    Comment = condition.Comment,
                    TotalKilometer = condition.TotalKilometer
                };
            }
        }

        public static VehicleConditionModel Create (RentCondition rent) {
            return Projection.Compile ().Invoke (rent);
        }
    }
}