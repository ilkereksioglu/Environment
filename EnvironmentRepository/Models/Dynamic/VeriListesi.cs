using EnvironmentRepository.Models.BaseModels;

namespace EnvironmentRepository.Models.Dynamic
{
    public class VeriListesi : SirketBoundBase
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string ClassName { get; set; }
        public string Ad { get; set; }
        public string Type { get; set; }
    }
}
