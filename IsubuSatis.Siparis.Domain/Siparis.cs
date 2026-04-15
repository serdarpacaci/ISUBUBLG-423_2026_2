using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Domain
{
    [Table("Siparis")]
    public class Siparis : CreationalEntity<int>
    {
        public string UserId { get; set; }
        public Address Address { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public decimal SiparisTutari { get; set; }
        public List<SiparisUrunBilgi> SiparisUrunleri { get; set; }
    }
}
