using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_numerico
    {
        public decimal cont;
        string erro = "";
        public Boolean renome_numerico(string caminho, string arquivo, decimal numero, string tipo)
        {
            //aplicando o renome.
            try
            {
                File.Move(caminho + @"\" + arquivo, caminho + @"\" + numero + tipo);
                return true;
            }
            catch(Exception e)
            {
                erro = e.Message + ": " + caminho + @"\" + numero + tipo;
                return false;
            }
        }
    }
    }
          