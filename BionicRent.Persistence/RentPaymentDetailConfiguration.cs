using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class RentPaymentDetailConfiguration : IEntityTypeConfiguration<RentPaymentDetail> {
        public void Configure (EntityTypeBuilder<RentPaymentDetail> builder) {
            builder.ToTable ("rent_payment_detail");

            builder.HasIndex (e => e.PaymentId)
                .HasName ("fk_payment");

            builder.HasIndex (e => e.RentId)
                .HasName ("fk_rent_payment_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.PaymentAmount).HasColumnName ("payment_amount");

            builder.Property (e => e.PaymentId).HasColumnName ("PAYMENT_ID");

            builder.Property (e => e.RentId).HasColumnName ("RENT_ID");

            builder.HasOne (d => d.Payment)
                .WithMany (p => p.RentPaymentDetail)
                .HasForeignKey (d => d.PaymentId)
                .HasConstraintName ("fk_payment");

            builder.HasOne (d => d.Rent)
                .WithMany (p => p.RentPaymentDetail)
                .HasForeignKey (d => d.RentId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_rent_payment");
        }
    }
}