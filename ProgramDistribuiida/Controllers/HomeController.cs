using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProgramDistribuiida.Models;
using System.Diagnostics;

namespace ProgramDistribuiida.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Water> _water;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Ciudad(string ciudad)
        {
            var watermodel = await GetList(ciudad);

            return View(watermodel);
        }
        public async Task<IActionResult> Registro(string Id)
        {
            var watermodel = await GetId(Id);
            return View(watermodel);
        }

        public async Task<IActionResult> Update(string id, string ciudad, decimal ph, decimal Hardness, decimal Solids, decimal Sulfate, decimal Turbidity, int potabilidad, string date)
        {
            Random rnd = new Random();

            if ((double)ph>=8.5)
            {
                ph= (decimal)(6.5 + (rnd.NextDouble() * (8.5 - 6.5)));
            }
            if ((double)Hardness >= 300)
            {
                Hardness = (decimal)(150 + (rnd.NextDouble() * (300 - 150)));
            }
            if ((double)Solids >= 500)
            {
                Solids = (decimal)(250 + (rnd.NextDouble() * (500 - 250)));
            }   
            if ((double)Sulfate >= 400)
            {
                Sulfate = (decimal)(200 + (rnd.NextDouble() * (400 - 200)));
            }
            if ((double)Turbidity >= 5)
            {
                Turbidity = (decimal)(2.5 + (rnd.NextDouble() * (5 - 2.5)));
            }
            Water water = new Water();
            water.id = id;
            water.Ciudad = ciudad;
            water.ph = ph;
            water.Hardness = Hardness;
            water.Solids = Solids;
            water.Sulfate = Sulfate;
            water.Turbidity = Turbidity;
            water.Potability = potabilidad;
            water.date = date;

            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync("https://localhost:44389/api/WaterControllerr", water);


                    // Redirect to the same page
                    return RedirectToAction("Registro", "Home", new { id = id });
                

            }
        }
            public async Task<List<Water>> GetId(string id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44389/api/WaterControllerr/" + id);

            if (response.IsSuccessStatusCode)
            {
                var JSONwater = await response.Content.ReadAsStringAsync();
                _water = JsonConvert.DeserializeObject<List<Water>>(JSONwater);
                return _water;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Water>> GetList(string ciudad)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44389/api/WaterControllerr/ciudad/"+ciudad);
            
            if (response.IsSuccessStatusCode)
            {
                var JSONwater = await response.Content.ReadAsStringAsync();
                _water = JsonConvert.DeserializeObject<List<Water>>(JSONwater);
                return _water;
            }
            else {      
                return null;     
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}