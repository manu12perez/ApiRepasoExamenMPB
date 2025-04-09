using ApiRepasoExamenMPB.Data;
using ApiRepasoExamenMPB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRepasoExamenMPB.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            return await this.context.Hospitales.ToListAsync();
        }

        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            return await this.context.Hospitales.FirstOrDefaultAsync(x => x.IdHospital == idHospital);
        }
        public async Task<List<Plantilla>> GetPlantillasAsync()
        {
            return await this.context.Plantillas.ToListAsync();
        }

        public async Task<Plantilla> FindPlantillaAsync(int idEmpleado)
        {
            return await this.context.Plantillas.FirstOrDefaultAsync(x => x.IdEmpleado == idEmpleado);
        }

        public async Task<List<Sala>> GetSalasAsync()
        {
            return await this.context.Salas.ToListAsync();
        }

        public async Task<Sala> FindSalaAsync(int salaCod)
        {
            return await this.context.Salas.FirstOrDefaultAsync(x => x.SalaCod == salaCod);
        }

        public async Task<int> GetMaxIdPlantilla()
        {
            var maxId = await this.context.Plantillas.MaxAsync(p => p.IdEmpleado);
            return maxId + 1;
        }

        public async Task InsertPlantillaAsync
            (int idHospital, int salaCod, string apellido, string funcion, string turno, int salario)
        {
            int idEmpleado = GetMaxIdPlantilla().Result;

            Plantilla plantilla = new Plantilla();
            plantilla.IdHospital = idHospital;
            plantilla.SalaCod = salaCod;
            plantilla.IdEmpleado = idEmpleado;
            plantilla.Apellido = apellido;
            plantilla.Funcion = funcion;
            plantilla.Turno = turno;
            plantilla.Salario = salario;

            await this.context.Plantillas.AddAsync(plantilla);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePlantillaAsync
            (int idHospital, int salaCod, int idEmpleado, string apellido, string funcion, string turno, int salario)
        {
            Plantilla plantilla = await this.FindPlantillaAsync(idEmpleado);
            plantilla.IdHospital = idHospital;
            plantilla.SalaCod = salaCod;
            plantilla.Apellido = apellido;
            plantilla.Funcion = funcion;
            plantilla.Turno = turno;
            plantilla.Salario = salario;

            await this.context.SaveChangesAsync();
        }

        public async Task DeletePlantillaAsync(int idEmpleado)
        {
            Plantilla plantilla = await this.FindPlantillaAsync(idEmpleado);

            this.context.Plantillas.Remove(plantilla);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<Plantilla>> GetPlantillasBySala(int salaCod)
        {
            Sala sala = await this.context.Salas.FirstOrDefaultAsync(x => x.SalaCod == salaCod);
            List<Plantilla> plantillas = await this.context.Plantillas.Where(x => x.IdHospital == sala.IdHospital).ToListAsync();
            return plantillas;
        }

        public async Task<List<Plantilla>> GetPlantillasByHospital(string nombre)
        {
            Hospital hospital = await this.context.Hospitales.FirstOrDefaultAsync(x => x.Nombre == nombre);
            List<Plantilla> plantillas = await this.context.Plantillas.Where(x => x.IdHospital == hospital.IdHospital).ToListAsync();
            return plantillas;
        }
    }
}
