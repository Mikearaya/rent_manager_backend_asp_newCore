/*
 * @CreateTime: Apr 25, 2019 3:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:17 PM
 * @Description: Modify Here, Please 
 */

using BionicRent.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistance.Identity {
    public class RoleClaimsConfiguration : IEntityTypeConfiguration<RoleClaims> {
        public void Configure (EntityTypeBuilder<RoleClaims> builder) {

            builder.ToTable ("SystemRoleClaims");
            builder.HasIndex (e => e.RoleId);

            builder.Property (e => e.Id).HasColumnType ("int(11)");

            builder.Property (e => e.ClaimType).HasColumnType ("longtext");

            builder.Property (e => e.ClaimValue).HasColumnType ("longtext");

            builder.Property (e => e.RoleId)
                .IsRequired ()
                .HasColumnType ("varchar(255)");

            builder.HasOne (d => d.Role)
                .WithMany (p => p.RoleClaims)
                .HasForeignKey (d => d.RoleId);
        }
    }
}