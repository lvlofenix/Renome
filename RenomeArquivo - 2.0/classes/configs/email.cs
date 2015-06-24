using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace RenomeArquivo___2._0.classes.etc
{
    class email
    {
        Boolean ssl;
        public void enviaEmail(string modo, int renomeados, int falhas, string log, string configs)
        {
            //tratando o log
            log = log.Replace(")", ")<p>");
            log = log.Replace("Caminho: ", "<FONT COLOR=#000080> Caminho: </FONT>");
            log = log.Replace("Arquivo", "<FONT COLOR=#4682B4>Arquivo</FONT>");
            log = log.Replace("||", "<FONT COLOR=#800000>||</FONT>");
            log = log.Replace("Falhou", "<FONT COLOR=#FF0000>Falhou</FONT>");
            log = log.Replace(" Renomeado com Sucesso!!", "<FONT COLOR=#008000> Renomeado com Sucesso!!</FONT>");
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "EMAIL")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(8) == "FALSE")
                    {
                        file.Close();
                        break;
                        
                    }
                    else
                    {
                        ssl = true;
                        MailMessage objEmail = new MailMessage();
                        objEmail.From = new MailAddress("renome.feedback@outlook.com");
                        //objEmail.ReplyTo = "";    
                        objEmail.To.Add("renome.feedback@outlook.com");
                        //objEmail.Bcc.Add("Email oculto");
                        objEmail.Priority = MailPriority.Normal;
                        objEmail.IsBodyHtml = true;
                        objEmail.Subject = "RENOME INFORMATIVO DE USO : " + DateTime.Now.ToShortDateString() + " as " + DateTime.Now.ToShortTimeString();
                        objEmail.Body = "<HTML>"
                                        + "<H3><B>USER:</B> <FONT COLOR=#F23D00>" + Environment.MachineName + "</FONT><P>"
                                        + "<B>ARCHIVES:</B> <FONT COLOR=#F23D00>" + renomeados + "</FONT><P>"
                                        + "<B>FALHAS:</B> <FONT COLOR=#F23D00>" + falhas + "</FONT><P>"
                                        + "<B>MOD:</B> <FONT COLOR=#F23D00>" + modo + @"</H3></FONT><P>"
                                        + "<B>_______________________________________________________</B><P>"
                                        + "<B>" + configs + "</B><P>"
                                        + "<B>_______________________________________________________</B><P>"
                                        +log
                                        + @"</HTML>";
                        objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                        objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                        SmtpClient objSmtp = new SmtpClient();
                        objSmtp.Host = "smtp.live.com";
                        objSmtp.EnableSsl = ssl;
                        objSmtp.Port = 587;
                        objSmtp.Credentials = new NetworkCredential("renome.feedback@outlook.com", "Pizza1992@");
                        objSmtp.Send(objEmail);
                        file.Close();
                        break;
                    }
                }
            }
        }
    }
}
