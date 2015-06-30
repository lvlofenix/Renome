using System;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_tamanho
    {
        public string erro = "";
        public Boolean renome_tamanho(string caminho, string arquivo, string tipo, string qual)
        {
            try
            {
                string peso = Convert.ToString(new FileInfo(caminho + @"\" + arquivo).Length);
                if (qual == "POR KB'S")
                {
                    //aplicando o renome.
                    peso = Convert.ToInt64(peso) / 1024 + "";
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + tipo);
                    return true;
                }
                else
                {
                    if (Convert.ToInt32(peso) < 1024)
                    {
                        peso = Convert.ToString((Convert.ToDouble(peso) / 1024) / 1024);
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + tipo);
                    }
                    else
                    {
                        peso = Convert.ToString((Convert.ToInt64(peso) / 1024f) / 1024f);
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + tipo);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                erro = e.Message;
                return false;
            }
        }
    }
}
