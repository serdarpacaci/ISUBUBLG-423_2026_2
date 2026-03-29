using AutoMapper;
using KatalogService.Dtos;
using KatalogService.Models;

namespace KatalogService
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Kategori, KategoriOlusturDto>().ReverseMap();
            CreateMap<Kategori, KategoriGuncelleDto>().ReverseMap();
            CreateMap<Kategori, KategoriDto>().ReverseMap();


            CreateMap<Urun, CreateOrUpdateUrunDto>().ReverseMap();
            CreateMap<Urun, UrunDto>().ReverseMap();

        }
    }
}
