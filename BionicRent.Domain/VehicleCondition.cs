/*
 * @CreateTime: Jun 7, 2019 9:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:54 AM
 * @Description: Modify Here, Please 
 */
namespace BionicRent.Domain {
    public class VehicleCondition {
        public int ConditionId { get; set; }
        public uint RentId { get; set; }
        public int WindowController { get; set; }
        public int SeatBelt { get; set; }
        public int SpareTire { get; set; }
        public int Wiper { get; set; }
        public int CrickWrench { get; set; }
        public int DashboardClose { get; set; }
        public int MudeProtecter { get; set; }
        public int SpokioOuter { get; set; }
        public int SpokioInner { get; set; }
        public int SunVisor { get; set; }
        public int MatInner { get; set; }
        public int WindProtecter { get; set; }
        public int Blinker { get; set; }
        public string Radio { get; set; }
        public string FuielLevel { get; set; }
        public int CigaretLighter { get; set; }
        public int FuielLid { get; set; }
        public int RadiatorLid { get; set; }
        public int Crick { get; set; }
        public string Comment { get; set; }
        public int TotalKilometer { get; set; }

        public virtual Rent Rent { get; set; }
    }
}