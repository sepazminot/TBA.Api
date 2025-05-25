using Microsoft.EntityFrameworkCore;
using TBA.Models;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
    }

    public DbSet<Evento> Evento { get; set; } = default!;
    public DbSet<Sesion> Sesion { get; set; } = default!;
    public DbSet<Ponente> Ponente { get; set; } = default!;
    public DbSet<Participante> Participante { get; set; } = default!;
    public DbSet<Inscripcion> Inscripcion { get; set; } = default!;
    public DbSet<Pago> Pago { get; set; } = default!;
    public DbSet<Certificado> Certificado { get; set; } = default!;
    public DbSet<MetodoPago> MetodoPago { get; set; } = default!;
    public DbSet<Asistencia> Asistencia { get; set; } = default!;
}