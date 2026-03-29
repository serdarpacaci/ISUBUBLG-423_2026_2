using KatalogService.Dtos;

namespace KatalogService.Services
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetKategoriler();
        Task KategoriOlustur(KategoriOlusturDto input);
        Task KategoriGuncelle(KategoriGuncelleDto input);
        Task KategoriSil(string id);

    }
}
