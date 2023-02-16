using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sksoft.Entity
{
    public class Mail
    {
        public int ID { get; set; }
        public string  Adi { get; set; }
        public string Email { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
    }
}
  

