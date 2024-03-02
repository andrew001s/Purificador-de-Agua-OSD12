using APIPlanta.Models;
using System;

namespace APIPlanta.Service
{
    public class DataService
    {
        public Water generate()
        {
            Random random = new Random();
            string[] ciudades = { "Quito", "Guayaquil", "Cuenca", "Riobamba" };
            decimal ph= (decimal)random.NextDouble() * 14;
            decimal hardness = (decimal)random.NextDouble() * 323;
            decimal solids = (decimal)random.NextDouble() * 60000;

            decimal sulfate = (decimal)random.NextDouble() * 500;

            decimal turbidity = (decimal)random.NextDouble() * 7;
            Water water = new Water
            {
                Ciudad = ciudades[random.Next(0, 4)],
                ph = ph,
                Hardness = hardness,
                Solids = solids,
                Sulfate = sulfate,
                Turbidity = turbidity,
                Date = DateTime.Now.ToString("g")
            };
            return water;
        }
        public Water GetWater()
        {
            return generate();
        }
    }
}
