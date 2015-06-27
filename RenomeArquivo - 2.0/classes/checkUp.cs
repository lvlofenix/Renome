using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RenomeArquivo___2._0.classes
{
    //
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
                    "TRAY = FALSE" + Environment.NewLine +
                    "EMAIL = TRUE" + Environment.NewLine +
                    "LANGUE = PTBR";
                    System.IO.File.WriteAllText(@".\conf.cf", configs);
                }
            }
            catch
            {

            }
        }
    }
}
