/*
 * @CreateTime: Jun 7, 2019 7:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:18 PMM
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
                .HasColumnName ("city")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Country)
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'Ethiopia'");

            builder.Property (e => e.CustomerName)
                .IsRequired ()
                .HasColumnName ("customer_name")
                .HasColumnType ("varchar(70)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("CURRENT_TIMESTAMP");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.DrivingLicenceId)
                .IsRequired ()
                .HasColumnName ("driving_licence_id")
                .HasColumnType ("varchar(45)");

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

            builder.Property (e => e.MobileNumber)
                .IsRequired ()
                .HasColumnName ("mobile_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.Nationality)
                .HasColumnName ("nationality")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'Ethiopian'");

            builder.Property (e => e.OtherPhone)
                .HasColumnName ("other_phone")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.PassportNumber)
                .HasColumnName ("passport_number")
                .HasColumnType ("varchar(45)");

        }
    }
}