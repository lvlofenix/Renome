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
            string erro = "";
            try
            {
                //aplicando o renome.
                if (System.IO.File.Exists(caminho + @"\" + nome + " - " + numero + tipo))
                {
                    int cont = 0;
                     while (System.IO.File.Exists(caminho + @"\" + "ARQUIVO" + " [" + cont + "]" + tipo))
                     {
                        cont++;
                     }
                     File.Move(caminho + @"\" + arquivo, caminho + @"\" + "ARQUIVO" + " [" + cont + "]" + tipo);
                    return true;
                }
                else
                {
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + " - " + numero + tipo);
                    return true;
                }
            }
            catch(Exception e)
            {
                erro = e.Message;
                return false;
            }
        }
    }
}
