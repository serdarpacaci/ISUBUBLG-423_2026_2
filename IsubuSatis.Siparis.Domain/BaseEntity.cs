using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Domain
{
    public abstract class BaseEntity<T> 
    {
        public T Id { get; set; }
    }

    public abstract class CreationalEntity<T> : BaseEntity<T>
    {
        public string CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
