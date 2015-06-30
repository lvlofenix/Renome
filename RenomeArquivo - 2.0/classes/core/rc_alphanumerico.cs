using System;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_alphanumerico
    {
        public string erro = "";
        public Boolean renome_alphanumerico(string caminho, string arquivo, decimal numero,char nome, string tipo)
        {
            try
            {
                File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + " - ["+numero+"]"+ tipo);
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
