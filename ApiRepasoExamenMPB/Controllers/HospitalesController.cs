using ApiRepasoExamenMPB.Models;
using ApiRepasoExamenMPB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiRepasoExamenMPB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        [HttpGet("Hospitales")]
        public async Task<ActionResult<List<Hospital>>> GetHospitales()
        {
            return await this.repo.GetHospitalesAsync();
        }

        [HttpGet("Hospital/{id}")]
        public async Task<ActionResult<Hospital>> FindHospital(int id)
        {
            return await this.repo.FindHospitalAsync(id);
        }

        [HttpGet("Salas")]
        public async Task<ActionResult<List<Sala>>> GetSalas()
        {
            return await this.repo.GetSalasAsync();
        }

        [HttpGet("Sala/{salacod}")]
        public async Task<ActionResult<Sala>> FindSala(int salacod)
        {
            return await this.repo.FindSalaAsync(salacod);
        }

        [HttpGet("Plantillas")]
        public async Task<ActionResult<List<Plantilla>>> GetPlantillas()
        {
            return await this.repo.GetPlantillasAsync();
        }

        [HttpGet("Plantilla/{id}")]
        public async Task<ActionResult<Plantilla>> FindPlantilla(int id)
        {
            return await this.repo.FindPlantillaAsync(id);
        }

        [HttpPost("InsertPlantilla")]
        public async Task<ActionResult> InsertPlantilla
            (int idHospital, int salaCod, string apellido, string funcion, string turno, int salario)
        {
            await this.repo.InsertPlantillaAsync(idHospital, salaCod, apellido, funcion, turno, salario);
            return Ok();
        }

        [HttpPut("UpdatePlantilla")]
        public async Task<ActionResult> UpdatePlantilla
            (int idHospital, int salaCod, int idEmpleado, string apellido, string funcion, string turno, int salario)
        {
            await this.repo.UpdatePlantillaAsync(idHospital, salaCod, idEmpleado, apellido, funcion, turno, salario);
            return Ok();
        }

        [HttpDelete("DeletePlantilla/{id}")]
        public async Task<ActionResult> DeletePlantilla(int id)
        {
            await this.repo.DeletePlantillaAsync(id);
            return Ok();
        }

        [HttpGet("PlantillasSala/{salaCod}")]
        public async Task<ActionResult<List<Plantilla>>> GetPlantillasBySala(int salaCod)
        {
            var plantillas = await this.repo.GetPlantillasBySala(salaCod);
            return plantillas;
        }

        [HttpGet("PlantillasHospital/{nombre}")]
        public async Task<ActionResult<List<Plantilla>>> GetPlantillasByHospital(string nombre)
        {
            var plantillas = await this.repo.GetPlantillasByHospital(nombre);
            return plantillas;
        }
    }
}
