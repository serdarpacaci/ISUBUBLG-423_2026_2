using IsubuSatis.Sepet.Models;

namespace IsubuSatis.Sepet.Service
{
    public interface ISepetService
    {
        Task SepetKaydet(SepetDto input);

        Task<SepetDto> GetUyeSepet(string userId);
        Task Sil(string userId);
    }
}
