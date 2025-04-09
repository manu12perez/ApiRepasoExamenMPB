using ApiRepasoExamenMPB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRepasoExamenMPB.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Sala> Salas { get; set; }
    }
}
