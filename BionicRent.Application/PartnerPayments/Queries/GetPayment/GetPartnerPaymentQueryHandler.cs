/*
 * @CreateTime: Jul 11, 2019 6:03 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 6:22 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Application.PartnerPayments.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.PartnerPayments.Queries.GetPayment {
    public class GetPartnerPaymentQueryHandler : IRequestHandler<GetPartnerPaymentQuery, PartnerPaymentDetailModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnerPaymentQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<PartnerPaymentDetailModel> Handle (GetPartnerPaymentQuery request, CancellationToken cancellationToken) {
            var result = await _database.RentPayment
                .Where (r => r.PartnerId != 0 && r.Id == request.Id)
                .Select (PartnerPaymentDetailModel.Projection)
                .FirstOrDefaultAsync ();

            if (result == null) {
                throw new NotFoundException ("Partner Payment", request.Id);
            }

            return result;
        }
    }
}