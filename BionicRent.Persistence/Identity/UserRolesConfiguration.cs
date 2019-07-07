/*
 * @CreateTime: Apr 25, 2019 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:20 PM
 * @Description: Modify Here, Please 
 */

using BionicRent.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistance.Identity {
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles> {
        public void Configure (EntityTypeBuilder<UserRoles> builder) {

            builder.ToTable ("SystemUserRoles");
            builder.HasIndex (e => e.RoleId);

            builder.Property (e => e.UserId).HasColumnType ("varchar(255)");

            builder.Property (e => e.RoleId).HasColumnType ("varchar(255)");

            builder.HasOne (d => d.Role)
                .WithMany (p => p.UserRoles)
                .HasForeignKey (d => d.RoleId);

            builder.HasOne (d => d.User)
                .WithMany (p => p.UserRoles)
                .HasForeignKey (d => d.UserId);
        }
    }
}