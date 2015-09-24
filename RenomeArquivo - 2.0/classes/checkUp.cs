using System;
using System.IO;
using System.Windows.Forms;

namespace RenomeArquivo___2._0.classes
{
    class checkUp
    {
        public void verificaIntegridade()
        {
            try
            {
                if (!System.IO.File.Exists(@".\conf.cf"))
                {
                    string configs = "##CONFIGS##" + Environment.NewLine +
                    "TURBO = FALSE" + Environment.NewLine +
                    "CONT = TRUE" + Environment.NewLine +
                    "LOG = TRUE" + Environment.NewLine +
                    "BARRA = TRUE" + Environment.NewLine +
                    "TRAY = TRUE" + Environment.NewLine +
                    "EMAIL = TRUE" + Environment.NewLine +
                    "LANGUE = PTBR" + Environment.NewLine +
                    "RELAE = TRUE";
                    System.IO.File.WriteAllText(@".\conf.cf", configs);
                }
                if (!System.IO.Directory.Exists(@".\scr"))
                {
                    System.IO.Directory.CreateDirectory(@".\scr");
                }
            }
            catch
            {
            }
        }

        public string[] verificaScripts()
        {
            DirectoryInfo dir = new DirectoryInfo(@".\scr");
            FileInfo[] scrp = dir.GetFiles("*.script");
            string[] caminhos = new string[scrp.Length];
            int i = -1;
            foreach (FileInfo f in scrp)
            {
                i++;
                caminhos[i] = f.Name.ToString();
            }
                return caminhos;
        }
    }
}
