using KatalogService.Dtos;
using KatalogService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UrunController : ControllerBase
    {
        private readonly IUrunService _urunService;

        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public async Task<List<UrunDto>> GetUrunler()
        {
            return await _urunService.GetUrunler();
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(CreateOrUpdateUrunDto input)
        {
            await _urunService.CreateOrUpdate(input);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UrunGuncelle(CreateOrUpdateUrunDto input)
        {
            await _urunService.CreateOrUpdate(input);

            return Ok();
        }

        [HttpDelete]
        public async Task UrunSil(string id)
        {
            await _urunService.Sil(id);
        }
    }
}


