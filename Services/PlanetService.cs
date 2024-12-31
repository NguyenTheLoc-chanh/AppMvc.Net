using AppMvc.Net.Models;

namespace AppMvc.Services
{
    public class PlanetService : List<PlanetModel>
    {
        public PlanetService()
        {
            Add(new PlanetModel(){
                Id = 1, 
                Name = "Mercury",
                VnName = "Sao thủy",
                Content = ""
            });
            Add(new PlanetModel(){
                Id = 2, 
                Name = "Mars",
                VnName = "Sao hỏa",
                Content = ""
            });
            Add(new PlanetModel(){
                Id = 3, 
                Name = "Saturn",
                VnName = "Sao thổ",
                Content = ""
            });
        }
    }
}