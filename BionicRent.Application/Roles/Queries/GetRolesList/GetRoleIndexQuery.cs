/*
 * @CreateTime: Jul 8, 2019 4:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:34 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicRent.Application.Roles.Models;
using MediatR;

namespace BionicRent.Application.Roles.Queries.GetRolesList {
    public class GetRoleIndexQuery : IRequest<IEnumerable<RoleIndexModel>> {
        private string filter { get; set; } = "";
        public string SearchString {
            get {
                return filter;
            }
            set {
                filter = (value == null) ? "" : value;
            }
        }

    }
}