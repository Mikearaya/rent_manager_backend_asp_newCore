/*
 * @CreateTime: Jun 7, 2019 7:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:10 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicRent.Persistence {
    public class RentConditionConfiguration : IEntityTypeConfiguration<RentCondition> {
        public void Configure (EntityTypeBuilder<RentCondition> builder) {
            builder.HasKey (e => e.ConditionId)
                .HasName ("PRIMARY");

            builder.ToTable ("rent_condition");

            builder.HasIndex (e => e.RentId)
                .HasName ("vehicle_condition_ibfk_1");

            builder.Property (e => e.ConditionId)
                .HasColumnName ("CONDITION_ID")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Blinker)
                .HasColumnName ("blinker")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.CigaretLighter)
                .HasColumnName ("cigaret_lighter")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Comment)
                .HasColumnName ("comment")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Crick)
                .HasColumnName ("crick")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.CrickWrench)
                .HasColumnName ("crick_wrench")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.DashboardClose)
                .HasColumnName ("dashboard_close")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.FuielLevel)
                .HasColumnName ("fuiel_level")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.FuielLid)
                .HasColumnName ("fuiel_lid")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.MatInner)
                .HasColumnName ("mat_inner")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.MudeProtecter)
                .HasColumnName ("mude_protecter")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.RadiatorLid)
                .HasColumnName ("radiator_lid")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Radio)
                .HasColumnName ("radio")
                .HasColumnType ("varchar(20)")
                .HasDefaultValueSql ("'None'");

            builder.Property (e => e.RentId).HasColumnName ("RENT_ID");

            builder.Property (e => e.SeatBelt)
                .HasColumnName ("seat_belt")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.SpareTire)
                .HasColumnName ("spare_tire")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.SpokioInner)
                .HasColumnName ("spokio_inner")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.SpokioOuter)
                .HasColumnName ("spokio_outer")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.SunVisor)
                .HasColumnName ("sun_visor")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.TotalKilometer)
                .HasColumnName ("total_kilometer")
                .HasColumnType ("int(11)");

            builder.Property (e => e.WindProtecter)
                .HasColumnName ("wind_protecter")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.WindowController)
                .HasColumnName ("window_controller")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Wiper)
                .HasColumnName ("wiper")
                .HasColumnType ("int(11)")
                .HasDefaultValueSql ("'0'");

            builder.HasOne (d => d.Rent)
                .WithMany (p => p.RentCondition)
                .HasForeignKey (d => d.RentId)
                .HasConstraintName ("rent_condition_ibfk_1");
        }
    }
}