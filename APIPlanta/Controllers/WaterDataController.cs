using APIPlanta.Models;
using APIPlanta.Service;
using Microsoft.AspNetCore.Mvc;

namespace APIPlanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterDataController
    {
        [HttpGet]
        public Water GetWater()
        {
            DataService dataService = new DataService();
            return dataService.GetWater();
        }
        
    }
}
