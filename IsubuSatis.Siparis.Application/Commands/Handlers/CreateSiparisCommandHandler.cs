using IsubuSatis.Siparis.Application.Commands.Dtos;
using IsubuSatis.Siparis.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Commands.Handlers
{
    public class CreateSiparisCommandHandler : IRequestHandler<CreateSiparisCommand,CreateSiparisDto>
    {
        private readonly SiparisDbContext _siparisDbContext;

        public CreateSiparisCommandHandler(SiparisDbContext siparisDbContext)
        {
            _siparisDbContext = siparisDbContext;
        }
        
        public Task<CreateSiparisDto> Handle(CreateSiparisCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var urunler = request.SiparisUrunleri;
            //_siparisDbContext.Siparisler.Add
            return Task.FromResult(new CreateSiparisDto());
        }
    }
}
