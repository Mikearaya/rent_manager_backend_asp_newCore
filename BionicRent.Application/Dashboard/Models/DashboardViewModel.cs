/*
 * @CreateTime: Jul 10, 2019 3:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 10, 2019 3:55 PM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.Dashboard.Models {
    public class DashboardViewModel {
        public int TotalCustomers { get; set; }
        public int TotalPartners { get; set; }
        public int TotalVehicles { get; set; }
        public int TotalRent { get; set; }
        public int ActiveRents { get; set; }
        public int OverdueRents { get; set; }
    }
}