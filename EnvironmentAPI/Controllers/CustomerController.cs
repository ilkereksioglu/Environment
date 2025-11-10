using EnvironmentRepository.Models.Musteri;
using EnvironmentServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentAPI.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly IMusteriService _musteri;
        public CustomerController(IMusteriService musteri)
        {
            _musteri = musteri;
        }

        public IActionResult GetCustomers()
        {
            return Json(new {});
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Musteri musteri)
        {
            /*
            var result = await _environment.AddCustomer(musteri);

            if (result.Succeeded)
            {
                return Json(new { Succeeded = result.Succeeded, Data = result.Data });
            }

            return Json(new { Succeeded = result.Succeeded, ErrorMessage = result.ErrorMessage });
            */
            return Json(new { });
        }
    }
}
