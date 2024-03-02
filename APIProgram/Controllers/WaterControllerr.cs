using APIMongo.Models;
using APIProgram.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using System.Net.Http.Headers;
using ThirdParty.Json.LitJson;

namespace APIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterControllerr : ControllerBase
    {
        public DbMongo _waterService;
        public HttpClient _httpClient;
        public WaterControllerr(DbMongo waterService)
        {
            _waterService = waterService;
        }

        [HttpGet]
        public ActionResult<List<Water>> GetAll()
        {
            return Ok(_waterService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<List<Water>> GetById(string id)
        {
            return Ok(_waterService.GetById(id));
        }

        [HttpPost]
        public ActionResult<Water> Create(Water water)
        {
            try
            {
   
                _waterService.Create(water);

                // Devolver el objeto Water creado como respuesta
                return Ok(water);
            }
            catch (Exception ex)
            {
                ex= new Exception("Error al crear el objeto Water");
                // Devolver un código de estado 500 y un mensaje de error en caso de excepción
                return StatusCode(500, ex);
            }
        }
    
        [HttpPut]
        public IActionResult Update(Water water)
        {

            _waterService.Update(water.Id.ToString(), water);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            _waterService.Remove(id);
            return Ok();
        }
        [HttpGet("ciudad/{ciudad}")]
        public ActionResult<List<Water>> GetByCiudad(string ciudad)
        {
            return Ok(_waterService.GetByCiudad(ciudad));
        }
    }
}
