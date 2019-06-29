/*
 * @CreateTime: Jun 7, 2019 7:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:19 PMM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class VehicleOwnerConfiguration : IEntityTypeConfiguration<VehicleOwner> {
        public void Configure (EntityTypeBuilder<VehicleOwner> builder) {
            builder.HasKey (e => e.OwnerId)
                .HasName ("PRIMARY");

            builder.ToTable ("vehicle_owner");

            builder.Property (e => e.OwnerId).HasColumnName ("OWNER_ID");

            builder.Property (e => e.City)
                .HasColumnName ("city")
                .HasColumnType ("varchar(50)")
                .HasDefaultValueSql ("'Addis Ababa'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.HouseNumber)
                .HasColumnName ("house_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.MobileNumber)
                .IsRequired ()
                .HasColumnName ("mobile_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.PartnerName)
                .IsRequired ()
                .HasColumnName ("partner_name")
                .HasColumnType ("varchar(70)");

            builder.Property (e => e.SubCity)
                .HasColumnName ("sub_city")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Wereda)
                .HasColumnName ("wereda")
                .HasColumnType ("varchar(45)");
        }
    }
}