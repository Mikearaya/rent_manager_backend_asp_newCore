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
    public class UserTokensConfiguration : IEntityTypeConfiguration<UserTokens> {
        public void Configure (EntityTypeBuilder<UserTokens> builder) {
            builder.ToTable ("SystemUserTokens");

            builder.Property (e => e.UserId).HasColumnType ("varchar(255)");

            builder.Property (e => e.LoginProvider).HasColumnType ("varchar(255)");

            builder.Property (e => e.Name).HasColumnType ("varchar(255)");

            builder.Property (e => e.Value).HasColumnType ("longtext");

            builder.HasOne (d => d.User)
                .WithMany (p => p.UserTokens)
                .HasForeignKey (d => d.UserId);
        }
    }
}