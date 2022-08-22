using BackEndBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBase.DataAccess.Mappings;

internal class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("tb_user");

        entity.Property(e => e.Id)
            .HasColumnName("id_user");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("nm_user")
            .HasMaxLength(100);

        entity.Property(e => e.Phone)
            .IsRequired()
            .HasColumnName("nr_phone")
            .HasMaxLength(13);

        entity.Property(e => e.Email)
            .IsRequired()
            .HasColumnName("st_email");

        entity.Property(e => e.BirthDate)
            .IsRequired()
            .HasColumnName("dt_birthDate");

        entity.Property(e => e.PasswordHash)
            .IsRequired()
            .HasColumnName("hs_password");
    }
}