using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle> {
        public void Configure (EntityTypeBuilder<Vehicle> builder) {
            builder.ToTable ("vehicle");

            builder.HasIndex (e => e.OwnerId)
                .HasName ("fk_car_owner_idx");

            builder.Property (e => e.VehicleId).HasColumnName ("VEHICLE_ID");

            builder.Property (e => e.Cc)
                .HasColumnName ("cc")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.ChassisNumber)
                .HasColumnName ("chassis_number")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Color)
                .IsRequired ()
                .HasColumnName ("color")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.CylinderCount)
                .HasColumnName ("cylinder_count")
                .HasColumnType ("int(11)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.FuielType)
                .IsRequired ()
                .HasColumnName ("fuiel_type")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.LibreNo)
                .HasColumnName ("libre_no")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.Make)
                .IsRequired ()
                .HasColumnName ("make")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Model)
                .IsRequired ()
                .HasColumnName ("model")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.MotorNumber)
                .HasColumnName ("motor_number")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.OwnerId).HasColumnName ("OWNER_ID");

            builder.Property (e => e.PlateCode)
                .IsRequired ()
                .HasColumnName ("plate_code")
                .HasColumnType ("varchar(5)");

            builder.Property (e => e.PlateNumber)
                .IsRequired ()
                .HasColumnName ("plate_number")
                .HasColumnType ("varchar(15)");

            builder.Property (e => e.TotalPassanger)
                .HasColumnName ("total_passanger")
                .HasColumnType ("tinyint(4)");

            builder.Property (e => e.Transmission)
                .HasColumnName ("transmission")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.YearMade)
                .IsRequired ()
                .HasColumnName ("year_made")
                .HasColumnType ("varchar(4)");

            builder.HasOne (d => d.Owner)
                .WithMany (p => p.Vehicle)
                .HasForeignKey (d => d.OwnerId)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_vehicle_owner");
        }
    }
}