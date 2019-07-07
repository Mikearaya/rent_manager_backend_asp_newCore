/*
 * @CreateTime: Jul 2, 2019 11:27 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:29 AM
 * @Description: Modify Here, Please  
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class SystemLookupConfiguration : IEntityTypeConfiguration<SystemLookup> {
        public void Configure (EntityTypeBuilder<SystemLookup> builder) {
            builder.ToTable ("system_lookup");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("CURRENT_TIMESTAMP");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(40)");

            builder.Property (e => e.Value)
                .IsRequired ()
                .HasColumnName ("value")
                .HasColumnType ("varchar(100)");
        }
    }
}