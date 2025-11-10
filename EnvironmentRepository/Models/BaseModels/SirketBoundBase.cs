using EnvironmentRepository.Models.Config;

namespace EnvironmentRepository.Models.BaseModels
{
    public abstract class SirketBoundBase
    {
        public Sirket? Sirket { get; set; }
        public int? SirketId { get; set; }
    }
}
