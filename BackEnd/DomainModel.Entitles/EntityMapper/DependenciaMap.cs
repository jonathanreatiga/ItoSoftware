using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainModel.Entitles.Models;

namespace DomainModel.Entitles.EntityMapper
{
    public class DependenciaMap : IEntityTypeConfiguration<Dependencia>
    {
        public void Configure(EntityTypeBuilder<Dependencia> builder)
        {
            builder.ToTable("Dependencia");
            builder.HasKey(e => e.IdDependencia);       
            builder.Property(e => e.IdDependencia).HasColumnName("IdDependencia");
            
            builder.HasMany(e => e.Empleados)
            .WithOne(e => e.Dependencia)
            .HasForeignKey(e => e.IdDependencia)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
            builder.Navigation(b => b.Empleados).UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}