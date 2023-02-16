using GSF.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Sksoft.Entity;
using System.Net;
using System.Net.Mail;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Mail = Sksoft.Entity.Mail;

namespace Sksoft.UI.Controllers
{
    public class MailController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Mail model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email: {0} ({1})</p><p>Mesaj:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("gsync263@gmail.com"));   
                message.From = new MailAddress("gsync263@gmail.com");  //Mesaj gönderecek mail
                message.Subject = "TEST";                              //Mesajın Konusu
                message.Body = string.Format(body, model.Adi, model.Konu, model.Email, model.Mesaj);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "gsync2363@gmail.com",              //Mesaj gönderecek olan mail ve şifresi
                        Password = "serkan23245363"  
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Gönder");
                }
            }
            return View(model);
        }
    }
}
