using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sksoft.Entity
{
    public class Kullanici
    {
        public int id { get; set; }

        public string ad { get; set; }

        public string sifre { get; set; }

        public virtual bool BeniHatirla { get; set; }
    }
}
