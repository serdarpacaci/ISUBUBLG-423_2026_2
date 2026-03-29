using KatalogService.Dtos;

namespace KatalogService.Services
{
    public interface IUrunService
    {
        Task<List<UrunDto>> GetUrunler();

        Task CreateOrUpdate(CreateOrUpdateUrunDto input);

        Task Sil(string id);
    }
}
