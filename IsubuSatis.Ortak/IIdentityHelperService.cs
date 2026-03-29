using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IsubuSatis.Ortak
{
    public interface IIdentityHelperService
    {
        string GetUserId();

        string GetUserName();
    }


    public class IdentityHelperService : IIdentityHelperService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentityHelperService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId()
        {
            if (!_contextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
                throw new UnauthorizedAccessException("Kullanıcı girişi yapılmamış.");

            return 
                _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c =>
                    c.Type == ClaimTypes.NameIdentifier)!.Value!;

        }

        public string GetUserName()
        {
            if (!_contextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
                throw new UnauthorizedAccessException("Kullanıcı girişi yapılmamış.");

            return
                _contextAccessor.HttpContext!.User.Identity!.Name!; 
        }
    }
}
