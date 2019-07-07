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
    public class UserLoginsConfiguration : IEntityTypeConfiguration<UserLogins> {
        public void Configure (EntityTypeBuilder<UserLogins> builder) {

            builder.ToTable ("SystemUserLogins");

            builder.HasIndex (e => e.UserId);

            builder.Property (e => e.LoginProvider).HasColumnType ("varchar(255)");

            builder.Property (e => e.ProviderKey).HasColumnType ("varchar(255)");

            builder.Property (e => e.ProviderDisplayName).HasColumnType ("longtext");

            builder.Property (e => e.UserId)
                .IsRequired ()
                .HasColumnType ("varchar(255)");

            builder.HasOne (d => d.User)
                .WithMany (p => p.UserLogins)
                .HasForeignKey (d => d.UserId);
        }
    }
}