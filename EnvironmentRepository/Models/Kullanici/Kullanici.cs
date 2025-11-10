using EnvironmentRepository.Models.Config;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentRepository.Models.Kullanici
{
    public class Kullanici : IdentityUser<int>
    {
        public List<Sirket> Sirketler { get; set; }
    }
}
