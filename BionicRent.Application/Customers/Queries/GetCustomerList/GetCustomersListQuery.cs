/*
 * @CreateTime: Jun 8, 2019 4:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:56 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Customers.Models;
using BionicRent.Application.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Customers.Queries.GetCustomerList {
    public class GetCustomersListQuery : ApiQueryString, IRequest<FilterResultModel<CustomerViewModel>> {

    }
}