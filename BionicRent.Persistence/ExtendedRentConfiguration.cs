/*
 * @CreateTime: Jun 7, 2019 7:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:05 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Jun 7, 2019 7:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:05 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class ExtendedRentConfiguration : IEntityTypeConfiguration<ExtendedRent> {
        public void Configure (EntityTypeBuilder<ExtendedRent> builder) {
            builder.HasKey (e => e.ExtendedId)
                .HasName ("PRIMARY");

            builder.ToTable ("extended_rent");

            builder.HasIndex (e => e.RentId)
                .HasName ("fk_rent_id_idx");

            builder.HasIndex (e => e.RepeatedExtendId)
                .HasName ("REPEATED_EXTEND_ID_UNIQUE")
                .IsUnique ();

            builder.Property (e => e.ExtendedId).HasColumnName ("EXTENDED_ID");

            builder.Property (e => e.ExtendedDays)
                .HasColumnName ("extended_days")
                .HasColumnType ("int(10)");

            builder.Property (e => e.ExtendedOn)
                .HasColumnName ("extended_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.OwnerRentingPrice)
                .HasColumnName ("owner_renting_price")
                .HasColumnType ("int(11)");

            builder.Property (e => e.RentId).HasColumnName ("RENT_ID");

            builder.Property (e => e.RentedPrice)
                .HasColumnName ("rented_price")
                .HasColumnType ("int(11)");

            builder.Property (e => e.RepeatedExtendId).HasColumnName ("REPEATED_EXTEND_ID");

            builder.HasOne (d => d.Rent)
                .WithMany (p => p.ExtendedRent)
                .HasForeignKey (d => d.RentId)
                .HasConstraintName ("fk_rent_id");

            builder.HasOne (d => d.RepeatedExtend)
                .WithOne (p => p.InverseRepeatedExtend)
                .HasForeignKey<ExtendedRent> (d => d.RepeatedExtendId)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_extended_rent_1");
        }
    }
}