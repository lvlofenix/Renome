using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_nome
    {
        public Boolean renome_nome(string caminho, string arquivo, decimal numero, string nome,string tipo)
        {
            try
            {
                //aplicando o renome.
                File.Move(caminho + @"\" + arquivo, caminho + @"\"+ nome + " - " + numero + tipo);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
