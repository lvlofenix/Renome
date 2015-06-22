using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RenomeArquivo___2._0.classes
{
    class rc_alphanumerico
    {
        string erro = "";
        public Boolean renome_alphanumerico(string caminho, string arquivo, decimal numero,char nome, string tipo)
        {
            try
            {
                File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + " - [" + numero + "]" + tipo);
                return true;
            }
            catch(Exception e)
            {
                erro = e.Message+": " + caminho + @"\" + nome + " - [" + numero + "]" + tipo;
                return false;
            }
        }
    }
}
