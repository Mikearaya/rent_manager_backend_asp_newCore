/*
 * @CreateTime: Jul 8, 2019 4:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:21 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicRent.Application.Users.Models;
using MediatR;

namespace BionicRent.Application.Users.Queries.GetUserList {
    public class GetUsersIndexQuery : IRequest<IEnumerable<UserIndexModel>> {

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