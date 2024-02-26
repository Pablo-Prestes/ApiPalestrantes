using DevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevEvents.API.Data
{
    public class DevEventsDbContext : DbContext
    {

        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {

        }
        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventsPalestrantes> DevEventsPalestrantes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(de => de.Titulo).IsRequired();

                e.Property(de => de.Descricao)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                e.Property(de => de.DataInicio)
                    .HasColumnName("Data_Inicio");

                e.Property(de => de.DataFim)
                    .HasColumnName("Data_Fim");

                e.HasMany(de => de.Palestrantes)
                    .WithOne()
                    .HasForeignKey(s => s.DevEventsId);

            });

            builder.Entity<DevEventsPalestrantes>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(dep => dep.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasMaxLength(60)
                    .IsFixedLength(false);



                e.Property(dep => dep.TituloPalestra)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsFixedLength(false);

               e.Property(dep => dep.DescricaoPalestra)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200)
                    .IsFixedLength(false);

                e.Property(dep => dep.LinkedinPerfil)                       
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200)
                    .IsFixedLength(false);
            });

        }
    }
}