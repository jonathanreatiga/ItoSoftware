using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainModel.Entitles.Models;

namespace DomainModel.Entitles.EntityMapper
{
    public class EmpleadoMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            //builder.HasIndex(x => x.IdEmpleado).HasName("PK_Empleado");
            builder.HasKey(x => x.IdEmpleado);

            builder.HasOne(e => e.Dependencia)
                .WithMany(b => b.Empleados)
                .HasForeignKey(e => e.IdDependencia)
                .HasConstraintName("FK_Empleado_Dependencia")
                .HasPrincipalKey(c => c.IdDependencia);
        }
    }
}