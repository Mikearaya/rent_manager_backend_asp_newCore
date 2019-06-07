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
                .IsRequired ()
                .HasColumnName ("city")
                .HasColumnType ("varchar(20)")
                .HasDefaultValueSql ("'Addis Ababa'");

            builder.Property (e => e.Country)
                .IsRequired ()
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'Ethiopia'");

            builder.Property (e => e.FirstName)
                .IsRequired ()
                .HasColumnName ("first_name")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.HouseNumber)
                .IsRequired ()
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

            builder.Property (e => e.RegisteredOn)
                .HasColumnName ("registered_on")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.Role)
                .IsRequired ()
                .HasColumnName ("role")
                .HasColumnType ("varchar(30)")
                .HasDefaultValueSql ("'multi'");

            builder.Property (e => e.SubCity)
                .IsRequired ()
                .HasColumnName ("sub_city")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.Wereda)
                .IsRequired ()
                .HasColumnName ("wereda")
                .HasColumnType ("varchar(5)");
        }
    }
}