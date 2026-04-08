using IsubuSatis.Indirim.Models;

namespace IsubuSatis.Indirim.Services
{
    public interface IIndirimService
    {
        Task<List<IndirimDto>> GetAllIndirim();
        Task<IndirimDto> GetById(int id);
        Task Kaydet(IndirimDto indirim);
        Task Guncelle(IndirimDto indirim);
        Task Sil(int id);
    }
}
