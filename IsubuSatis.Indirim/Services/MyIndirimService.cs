using Dapper;
using IsubuSatis.Indirim.Models;
using Npgsql;
using System.Data;

namespace IsubuSatis.Indirim.Services
{
    public class MyIndirimService : IIndirimService
    {

        private readonly IDbConnection dbConnection;

        public MyIndirimService(IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("Default");
            dbConnection = new NpgsqlConnection(constr);
        }

        public async Task<List<IndirimDto>> GetAllIndirim()
        {
            var sonuc = await dbConnection
                .QueryAsync<IndirimDto>("select * from indirim");

            return sonuc.ToList();

        }

        public async Task<IndirimDto> GetById(int id)
        {
            var sonuc = await dbConnection
                .QueryAsync<IndirimDto>("select * from indirim where id=@Id",
                new
                {
                    Id = id
                });

            return sonuc.FirstOrDefault();
        }

        public async Task Guncelle(IndirimDto indirim)
        {
            var sonuc = await dbConnection
                .ExecuteAsync("update indirim set UserId = @UserId, Oran = @Oran, Kod= @Kod, IsActive=@IsActive",
               indirim);
        }

        public async Task Kaydet(IndirimDto indirim)
        {
            var sonuc = await dbConnection
                 .ExecuteAsync("insert into indirim (UserId,Oran,Kod,IsActive) values (@UserId,@Oran,@Kod,@IsActive)",
                indirim);
        }

        public async Task Sil(int id)
        {
            var sonuc = await dbConnection.ExecuteAsync("delete from indirim where id=@Id",
                new
                {
                    Id = id
                });
        }
    }
}
