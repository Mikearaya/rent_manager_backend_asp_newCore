/*
 * @CreateTime: Jul 1, 2019 3:13 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 3:14 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Reports.Queries {
    public class GetRentHistoryQuery : ApiQueryString, IRequest<FilterResultModel<RentHistoryModel>> {

    }
}