/*
 * @CreateTime: Jun 28, 2019 3:00 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:27 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.PartnerPayments.Commands.CreateCommand {
    public class AddPartnerPaymentCommandHandler : IRequestHandler<AddPartnerPaymentCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public AddPartnerPaymentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (AddPartnerPaymentCommand request, CancellationToken cancellationToken) {
            RentPayment payments = new RentPayment () {
                PartnerId = request.PartnerId,
                Date = request.Date
            };

            foreach (var item in request.Rents) {
                payments.RentPaymentDetail.Add (new RentPaymentDetail () {
                    PaymentAmount = item.Amount,
                        RentId = item.RentId
                });
            }

            await _database.RentPayment.AddRangeAsync (payments);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}