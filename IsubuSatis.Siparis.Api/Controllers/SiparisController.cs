using IsubuSatis.Siparis.Application.Commands;
using IsubuSatis.Siparis.Application.Queries;
using IsubuSatis.Siparis.Application.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.Siparis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {

        private IMediator _mediator;

        public SiparisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSiparisler()
        {
            var userId = "";
            var sonuc = await _mediator.Send(
                new GetSiparislerByUserIdQuery() { UserId = userId });

            return Ok(sonuc);
        }


        [HttpPost]
        public async Task<IActionResult> SiparisKaydet(CreateSiparisCommand input)
        {
            input.UserId = "tokendan gelecek";
            var sonuc = await _mediator.Send(input);

            return Ok(sonuc);
        }
    }
}
