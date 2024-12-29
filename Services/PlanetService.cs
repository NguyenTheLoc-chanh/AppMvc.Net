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
                VnName = "Abc",
                Content = ""
            });
            Add(new PlanetModel(){
                Id = 2, 
                Name = "A",
                VnName = "Abc",
                Content = ""
            });
            Add(new PlanetModel(){
                Id = 3, 
                Name = "B",
                VnName = "Abc",
                Content = ""
            });
        }
    }
}