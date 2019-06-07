/*
 * @CreateTime: Jun 7, 2019 7:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:03 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure (EntityTypeBuilder<Customer> builder) {
            builder.ToTable ("customer");

            builder.Property (e => e.CustomerId).HasColumnName ("CUSTOMER_ID");

            builder.Property (e => e.City)
                .IsRequired ()
                .HasColumnName ("city")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Country)
                .IsRequired ()
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DrivingLicenceId)
                .IsRequired ()
                .HasColumnName ("driving_licence_id")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.FirstName)
                .IsRequired ()
                .HasColumnName ("first_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.HotelName)
                .HasColumnName ("hotel_name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.HotelPhone)
                .HasColumnName ("hotel_phone")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.HouseNo)
                .IsRequired ()
                .HasColumnName ("house_no")
                .HasColumnType ("varchar(10)");

            builder.Property (e => e.LastName)
                .IsRequired ()
                .HasColumnName ("last_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.MobileNumber)
                .IsRequired ()
                .HasColumnName ("mobile_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.Nationality)
                .IsRequired ()
                .HasColumnName ("nationality")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'Ethiopian'");

            builder.Property (e => e.OtherPhone)
                .HasColumnName ("other_phone")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.PassportNumber)
                .HasColumnName ("passport_number")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.RegisteredOn)
                .HasColumnName ("registered_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();
        }
    }
}