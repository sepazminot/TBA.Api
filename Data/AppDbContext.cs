using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBA.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TBA.Models.Evento> Evento { get; set; } = default!;

public DbSet<TBA.Models.Sesion> Sesion { get; set; } = default!;

public DbSet<TBA.Models.Ponente> Ponente { get; set; } = default!;

public DbSet<TBA.Models.Participante> Participante { get; set; } = default!;

public DbSet<TBA.Models.Inscripcion> Inscripcion { get; set; } = default!;

public DbSet<TBA.Models.Pago> Pago { get; set; } = default!;

public DbSet<TBA.Models.Certificado> Certificado { get; set; } = default!;

public DbSet<TBA.Models.MetodoPago> MetodoPago { get; set; } = default!;

public DbSet<TBA.Models.Asistencia> Asistencia { get; set; } = default!;
    }
