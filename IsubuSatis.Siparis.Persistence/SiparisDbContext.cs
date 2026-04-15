using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IsubuSatis.Siparis.Persistence
{
    public class SiparisDbContext :DbContext
    {
        public SiparisDbContext(DbContextOptions options) : base(options)
        {
        }

        protected SiparisDbContext()
        {
        }

        public DbSet<Domain.Siparis> Siparisler { get; set; }
        public DbSet<Domain.Address> Adressler { get; set; }
        public DbSet<Domain.SiparisUrunBilgi> UrunBilgiler { get; set; }

        
    }
}
