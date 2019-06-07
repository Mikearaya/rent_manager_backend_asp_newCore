/*
 * @CreateTime: Jun 7, 2019 7:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:08 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class RentPaymentConfiguration : IEntityTypeConfiguration<RentPayment> {
        public void Configure (EntityTypeBuilder<RentPayment> builder) {
            builder.HasKey (e => e.PaymentId)
                .HasName ("PRIMARY");

            builder.ToTable ("rent_payment");

            builder.HasIndex (e => e.RentId)
                .HasName ("fk_rent_payment_idx");

            builder.Property (e => e.PaymentId).HasColumnName ("PAYMENT_ID");

            builder.Property (e => e.PaymentAmount)
                .HasColumnName ("payment_amount")
                .HasColumnType ("int(11)");

            builder.Property (e => e.PaymentDate)
                .HasColumnName ("payment_date")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.RentId).HasColumnName ("RENT_ID");

            builder.HasOne (d => d.Rent)
                .WithMany (p => p.RentPayment)
                .HasForeignKey (d => d.RentId)
                .HasConstraintName ("fk_rent_payment");
        }
    }
}