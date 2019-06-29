/*
 * @CreateTime: Jun 29, 2019 2:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jun 29, 2019 2:35 PM 
 * @Description: Modify Here, Please  
 */
/*
 * @CreateTime: Jun 29, 2019 2:34 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:35 PM
 * @Description: Modify Here, Please  
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class RentPaymentConfiguration : IEntityTypeConfiguration<RentPayment> {
        public void Configure (EntityTypeBuilder<RentPayment> builder) {
            builder.ToTable ("rent_payment");

            builder.HasIndex (e => e.CustomerId)
                .HasName ("fk_customer_payment");

            builder.HasIndex (e => e.PartnerId)
                .HasName ("partner_payment_fk");

            builder.Property (e => e.CustomerId).HasColumnName ("CUSTOMER_ID");

            builder.Property (e => e.Date)
                .HasColumnName ("date")
                .HasColumnType ("datetime");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.PartnerId).HasColumnName ("PARTNER_ID");

            builder.HasOne (d => d.Customer)
                .WithMany (p => p.RentPayment)
                .HasForeignKey (d => d.CustomerId)
                .HasConstraintName ("fk_customer_payment");

            builder.HasOne (d => d.Partner)
                .WithMany (p => p.RentPayment)
                .HasForeignKey (d => d.PartnerId)
                .HasConstraintName ("partner_payment_fk");
        }
    }
}