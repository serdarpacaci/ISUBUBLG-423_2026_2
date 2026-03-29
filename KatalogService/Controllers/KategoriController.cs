using KatalogService.Dtos;
using KatalogService.Models;
using KatalogService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public async Task<List<KategoriDto>> GetKategoriler()
        {
            return await _kategoriService.GetKategoriler();
        }

        [HttpPost]
        public async Task<IActionResult> KategoriOlustur(KategoriOlusturDto input)
        {
            await _kategoriService.KategoriOlustur(input);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> KategoriGuncelle(KategoriGuncelleDto input)
        {
            await _kategoriService.KategoriGuncelle(input);

            return Ok();
        }

        [HttpDelete]
        public async Task KategoriSil(string id)
        {
            await _kategoriService.KategoriSil(id);
        }
    }
}
