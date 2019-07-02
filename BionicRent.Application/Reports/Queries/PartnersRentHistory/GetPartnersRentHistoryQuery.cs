/*
 * @CreateTime: Jul 1, 2019 4:03 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 4:14 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Reports.Queries {
    public class GetPartnersRentHistoryQuery : ApiQueryString, IRequest<FilterResultModel<PartnersRentHistoryModel>> {

    }
}