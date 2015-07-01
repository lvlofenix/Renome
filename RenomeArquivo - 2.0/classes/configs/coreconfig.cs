using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes.configs
{
    class coreconfig
    {
        string text = File.ReadAllText(@".\conf.cf");

        //contadores
        public Boolean ativa_contadores()
        {
            if (text.IndexOf("CONT = FALSE") != -1)
            {
                //pb_cont.Image = Properties.Resources.lightbulb;
                text = text.Replace("CONT = FALSE", "CONT = TRUE");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                //pb_cont.Image = Properties.Resources.lightbulb_off;
                text = text.Replace("CONT = TRUE", "CONT = FALSE");
                File.WriteAllText(@".\conf.cf", text);
                return false;
            }
        }

        //log
        public Boolean ativa_log()
        {
            if (text.IndexOf("LOG = FALSE") != -1)
            {
                text = text.Replace("LOG = FALSE", "LOG = TRUE");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                text = text.Replace("LOG = TRUE", "LOG = FALSE");
                File.WriteAllText(@".\conf.cf", text);
                return false;
            }
        }

        //barraprogress
        public Boolean ativa_barra()
        {
            if (text.IndexOf("BARRA = FALSE") != -1)
            {
                text = text.Replace("BARRA = FALSE", "BARRA = TRUE");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                text = text.Replace("BARRA = TRUE", "BARRA = FALSE");
                File.WriteAllText(@".\conf.cf", text);
                return false;
            }
        }

        //tray
        public Boolean ativa_tray()
        {
            if (text.IndexOf("TRAY = FALSE") != -1)
            {
                text = text.Replace("TRAY = FALSE", "TRAY = TRUE");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                text = text.Replace("TRAY = TRUE", "TRAY = FALSE");
                File.WriteAllText(@".\conf.cf", text);
                return false;
            }
        }

        //relaERRO
        public Boolean ativa_relae()
        {
            if (text.IndexOf("RELAE = FALSE") != -1)
            {
                text = text.Replace("RELAE = FALSE", "RELAE = TRUE");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }

            else
            {
                text = text.Replace("RELAE = TRUE", "RELAE = FALSE");
                File.WriteAllText(@".\conf.cf", text);
                return false;
            }
        }

        //ativaemail
        public Boolean ativa_email()
        {
            if (text.IndexOf("EMAIL = FALSE") != -1)
            {
                text = text.Replace("EMAIL = FALSE", "EMAIL = TRUE");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                text = text.Replace("EMAIL = TRUE", "EMAIL = FALSE");
                File.WriteAllText(@".\conf.cf", text);
                return false;
            }
        }

        //lingua ptbr
        public Boolean lingua_ptbr()
        {
            if (text.IndexOf("LANGUE = INGL") != -1)
            {
                text = text.Replace("LANGUE = INGL", "LANGUE = PTBR");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                return false;
            }
        }

        //lingua us
        public Boolean lingua_us()
        {
            if (text.IndexOf("LANGUE = PTBR") != -1)
            {
                text = text.Replace("LANGUE = PTBR", "LANGUE = INGL");
                File.WriteAllText(@".\conf.cf", text);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
