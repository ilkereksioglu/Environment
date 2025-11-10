using EnvironmentAPI.Models.Response;
using EnvironmentRepository.Models.Musteri;
using EnvironmentServices.DTO.MusteriDTO;
using EnvironmentServices.ServiceResult;
using EnvironmentServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentAPI.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        private readonly IMusteriService _musteri;
        public MusteriController(IMusteriService musteri)
        {
            _musteri = musteri;
        }

        [HttpGet]
        [Route(Routing.MusteriDetay)] 
        public async Task<IActionResult> MusteriDetay([FromRoute]int id)
        {
            var result = await _musteri.MusteriGetir(id);
            if (result.Succeeded)
            {
                return Json(new ApiResponse<MusteriDetailDTO>(result));
            }
            else if(result.Data == null)
            {
                return NotFound(new ApiResponse<MusteriDetailDTO>(result));
            }

            return BadRequest(new ApiResponse<MusteriDetailDTO>(result));
        }

        [HttpGet]
        [Route(Routing.Musteriler)]
        public async Task<IActionResult> Musteriler()
        {
            var result = await _musteri.TumMusterileriGetir();
            if (result.Succeeded)
            {
                return Json(new ApiResponse<ServiceResultData<List<Musteri>>>(result));
            }

            return BadRequest(new ApiResponse<ServiceResultData<List<Musteri>>>(result));
        }

        [HttpPost]
        [Route(Routing.MusteriDetay)]
        public async Task<IActionResult> MusteriEkle([FromBody]MusteriEkleGuncelleDTO musteri)
        {
            var result = await _musteri.MusteriEkleGuncelle(musteri);

            if (result.Succeeded)
            {
                return Json(new ApiResponse<Musteri>(result));
            }

            return BadRequest(new ApiResponse<Musteri>(result));
        }
    }
}
