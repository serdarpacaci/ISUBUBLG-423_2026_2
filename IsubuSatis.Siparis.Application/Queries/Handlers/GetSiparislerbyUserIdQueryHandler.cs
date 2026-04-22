using IsubuSatis.Siparis.Application.Queries.Dtos;
using IsubuSatis.Siparis.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Queries.Handlers
{
    
    public class GetSiparislerbyUserIdQueryHandler : IRequestHandler<GetSiparislerByUserIdQuery, List<SiparisDto>>
    {
        private readonly SiparisDbContext _siparisDbContext;

        public GetSiparislerbyUserIdQueryHandler(SiparisDbContext siparisDbContext)
        {
            _siparisDbContext = siparisDbContext;
        }

        public Task<List<SiparisDto>> Handle(GetSiparislerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            return Task.FromResult(new List<SiparisDto>());
        }
    }
}
