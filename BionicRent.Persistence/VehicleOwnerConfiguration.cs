/*
 * @CreateTime: Jun 7, 2019 7:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:11 PM
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
                .IsRequired ()
                .HasColumnName ("city")
                .HasColumnType ("varchar(50)")
                .HasDefaultValueSql ("'Addis Ababa'");

            builder.Property (e => e.FirstName)
                .IsRequired ()
                .HasColumnName ("first_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.HouseNumber)
                .IsRequired ()
                .HasColumnName ("house_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.LastName)
                .IsRequired ()
                .HasColumnName ("last_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.MobileNumber)
                .IsRequired ()
                .HasColumnName ("mobile_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.RegisteredOn)
                .HasColumnName ("registered_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.SubCity)
                .IsRequired ()
                .HasColumnName ("sub_city")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.UpdatedOn)
                .HasColumnName ("updated_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Wereda)
                .IsRequired ()
                .HasColumnName ("wereda")
                .HasColumnType ("varchar(45)");
        }
    }
}