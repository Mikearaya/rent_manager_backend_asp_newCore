/*
 * @CreateTime: Jun 29, 2019 4:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:57 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.PartnerPayments.Commands.UpdateCommand {
    public class UpdatePartnerPaymentCommandHandler : IRequestHandler<UpdatePartnerPaymentCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public UpdatePartnerPaymentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatePartnerPaymentCommand request, CancellationToken cancellationToken) {
            var payment = await _database.RentPayment
                .Include (p => p.RentPaymentDetail)
                .FirstOrDefaultAsync (p => p.Id == request.Id);

            if (payment == null) {
                throw new NotFoundException ("Payment", request.Id);
            }

            payment.Date = request.Date;
            payment.PartnerId = request.PartnerId;

            foreach (var item in request.Rents) {

                if (item.Id != 0) {
                    var o = payment.RentPaymentDetail.FirstOrDefault (i => i.Id == item.Id);
                    o.PaymentAmount = item.Amount;
                    o.RentId = item.RentId;
                } else {
                    payment.RentPaymentDetail.Add (new RentPaymentDetail () {
                        RentId = item.RentId,
                            PaymentAmount = item.Amount
                    });
                }
            }

            foreach (var id in request.DeletedIds) {
                var o = payment.RentPaymentDetail.FirstOrDefault (i => i.Id == id);
                _database.RentPaymentDetail.Remove (o);
            }

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}