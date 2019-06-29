/*
 * @CreateTime: Jun 7, 2019 7:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:04 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
        public void Configure (EntityTypeBuilder<Employee> builder) {
            builder.ToTable ("employee");

            builder.Property (e => e.EmployeeId).HasColumnName ("EMPLOYEE_ID");

            builder.Property (e => e.City)
                .HasColumnName ("city")
                .HasColumnType ("varchar(20)")
                .HasDefaultValueSql ("'Addis Ababa'");

            builder.Property (e => e.Country)
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'Ethiopia'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.FirstName)
                .IsRequired ()
                .HasColumnName ("first_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.HouseNumber)
                .HasColumnName ("house_number")
                .HasColumnType ("varchar(10)");

            builder.Property (e => e.LastName)
                .IsRequired ()
                .HasColumnName ("last_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.PhoneNumber)
                .IsRequired ()
                .HasColumnName ("phone_number")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Role)
                .HasColumnName ("role")
                .HasColumnType ("varchar(30)")
                .HasDefaultValueSql ("'multi'");

            builder.Property (e => e.SubCity)
                .HasColumnName ("sub_city")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.Wereda)
                .HasColumnName ("wereda")
                .HasColumnType ("varchar(5)");
        }
    }
}