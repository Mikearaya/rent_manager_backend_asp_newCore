/*
 * @CreateTime: Jul 10, 2019 9:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jul 10, 2019 9:29 PM 
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Rents.Models {
    public class RentContractView {
        public uint Id { get; set; }
        public string CustomerName { get; set; }
        public string PlateCode { get; set; }
        public string PlateNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string RentedBy { get; set; }
        public DateTime? Date { get; set; }
        public decimal RentPrice { get; set; }
        public string ChassisNumber { get; set; }
        public string LibreNumber { get; set; }
        public string MotorNumber { get; set; }
        public string FuielType { get; set; }
        public string TotalPassangers { get; set; }
        public string VehicleCC { get; set; }
        public string HouseNumber { get; set; }
        public string HotelName { get; set; }
        public string HotelNumber { get; set; }
        public string MainPhone { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string YearMade { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleType { get; set; }
        public string CylinderCount { get; set; }

        public int Duration {
            get {
                return ReturnDate.Value.Subtract (StartDate).Days;
            }
            set { }
        }
        public decimal? CollateralDeposit { get; set; }
        public VehicleConditionModel VehicleCondition { get; set; }

        public static Expression<Func<Rent, RentContractView>> Projection {
            get {
                return rent => new RentContractView () {
                    Id = rent.RentId,
                    VehicleMake = rent.Vehicle.Make,
                    VehicleModel = rent.Vehicle.Model,
                    YearMade = rent.Vehicle.YearMade,
                    VehicleColor = rent.Vehicle.ColorNavigation.Value,
                    VehicleType = rent.Vehicle.TypeNavigation.Value,
                    CylinderCount = rent.Vehicle.CylinderCount.ToString (),
                    CustomerName = rent.Customer.CustomerName,
                    HotelName = rent.Customer.HotelName,
                    HotelNumber = rent.Customer.HotelPhone,
                    HouseNumber = rent.Customer.HouseNo,
                    MainPhone = rent.Customer.MobileNumber,
                    Nationality = rent.Customer.Nationality,
                    City = rent.Customer.City,
                    Country = rent.Customer.Country,
                    DrivingLicenseNo = rent.Customer.DrivingLicenceId,
                    PassportNumber = rent.Customer.PassportNumber,
                    PlateNumber = rent.Vehicle.PlateNumber,
                    PlateCode = rent.Vehicle.PlateCode,
                    StartDate = rent.StartDate,
                    ReturnDate = rent.ReturnDate,
                    Date = rent.DateAdded,
                    RentPrice = rent.RentedPrice,
                    CollateralDeposit = rent.ColateralDeposit,
                    VehicleCC = rent.Vehicle.Cc,
                    ChassisNumber = rent.Vehicle.ChassisNumber,
                    MotorNumber = rent.Vehicle.MotorNumber,
                    FuielType = rent.Vehicle.FuielType,
                    TotalPassangers = rent.Vehicle.TotalPassanger.ToString (),
                    VehicleCondition = VehicleConditionModel.Create (rent.RentCondition.FirstOrDefault ())
                };
            }
        }
    }
}