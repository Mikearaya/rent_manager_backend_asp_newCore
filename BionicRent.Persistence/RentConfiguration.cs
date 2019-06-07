/*
 * @CreateTime: Jun 7, 2019 7:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:07 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class RentConfiguration : IEntityTypeConfiguration<Rent> {
        public void Configure (EntityTypeBuilder<Rent> builder) {
            builder.ToTable ("rent");

            builder.HasIndex (e => e.RentedBy)
                .HasName ("fk_renting_staff_idx");

            builder.HasIndex (e => e.VehicleId)
                .HasName ("fk_rented_car_idx");

            builder.HasIndex (e => new { e.CustomerId, e.RentedBy })
                .HasName ("fk_rent_client_idx");

            builder.Property (e => e.RentId).HasColumnName ("RENT_ID");

            builder.Property (e => e.AddedOn)
                .HasColumnName ("added_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.ColateralDeposit)
                .HasColumnName ("colateral_deposit")
                .HasColumnType ("int(11)");

            builder.Property (e => e.CustomerId).HasColumnName ("CUSTOMER_ID");

            builder.Property (e => e.EndDate)
                .HasColumnName ("end_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.OwnerRentingPrice)
                .HasColumnName ("owner_renting_price")
                .HasColumnType ("int(11)");

            builder.Property (e => e.RentedBy).HasColumnName ("RENTED_BY");

            builder.Property (e => e.RentedPrice)
                .HasColumnName ("rented_price")
                .HasColumnType ("int(11)");

            builder.Property (e => e.ReturnDate)
                .HasColumnName ("return_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.StartDate)
                .HasColumnName ("start_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.Status)
                .IsRequired ()
                .HasColumnName ("status")
                .HasColumnType ("enum('RENTED','RETURNED')")
                .HasDefaultValueSql ("'RENTED'");

            builder.Property (e => e.UpdatedOn)
                .HasColumnName ("updated_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.VehicleId).HasColumnName ("VEHICLE_ID");

            builder.HasOne (d => d.Customer)
                .WithMany (p => p.Rent)
                .HasForeignKey (d => d.CustomerId)
                .HasConstraintName ("fk_rented_by");

            builder.HasOne (d => d.RentedByNavigation)
                .WithMany (p => p.Rent)
                .HasForeignKey (d => d.RentedBy)
                .HasConstraintName ("fk_renting_employee");

            builder.HasOne (d => d.Vehicle)
                .WithMany (p => p.Rent)
                .HasForeignKey (d => d.VehicleId)
                .HasConstraintName ("fk_rented_car");

        }
    }
}