using System;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_nome
    {
        public string erro = "";
        public Boolean renome_nome(string caminho, string arquivo, decimal numero, string nome,string tipo)
        {
            try
            {
                //aplicando o renome.
                File.Move(caminho + @"\" + arquivo, caminho + @"\"+ nome + " - " + numero + tipo);
                return true;
            }
            catch (Exception e)
            {
                erro = e.Message;
                return false;
            }
        }
    }
}
