using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sksoft.Entity
{
    public class Hakkimizda : BaseEntity
    {
        public int ID { get; set; }
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public string Resim { get; set; }
    }
}
