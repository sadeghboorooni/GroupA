using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using ADVIEWER.DAL;

namespace ADVIEWER.Member
{
    public partial class TestMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment adv = ml.Advertisments.Where(t => t.StarCount == 2).First();
            var fromAddress = new MailAddress("adviewer.ir@gmail.com", "hamid");
            var toAddress = new MailAddress("hamidfalah@gmail.com", "hamidfalah");
            string src = "http://www.adviewer.ir"+adv.Pic.Replace("~","");
            const string fromPassword = "hamid123";
            string subject = "testSubject";
            string body = "<h1></h1><br><table style = \" direction:rtl;\">" +
                "<tr> <td colspan =\"2\">"+
                "<a href =\"http://www.adviewer.ir\">" +
                "<img src=\"http://www.adviewer.ir/Styles/Images/Logo.png \" style = \"max-width:24%; float:right\" />" +
                "</a>"+
                "</td> </tr>"+
                "<tr> <td>"+
                adv.Description+
                 "</td> </tr>"+
                 "<tr><td colspan = \"2\">"+
                 "<a href = \"http://www.adviwer.ir/advcontent.aspx?id=" + adv.ID + "\">" +
                " <img src = \""+src+"\" style = \"max-width:200px; float:right\"/>"+
                "</a>"+
                 "</td> </tr>";
            if(adv.StateCity != null)
            if (adv.StateCity.StateId != null)
            {
                body += "<tr><td>" +
                    adv.StateCity.State.Name + "شهر:" + adv.StateCity.Name +
                   "</tr></td>"
                    ;
            }
            else
            {
                body += "<tr><td>" +
                "همه ی شهرستان های استان" +" "+ adv.StateCity.Name +
                   "</tr></td>";
            }
            

                 


               body+=  "</table>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}