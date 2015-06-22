using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RenomeArquivo___2._0.classes
{
    class rc_data
    {
        public Boolean renomeData(string caminho, string arquivo,string tipo,string qual, int i)
        {
            string erro = "";
            try
            {
                //pegando a data e renomeando arquivo.
                DateTime fileCreateDate = File.GetCreationTime(caminho + @"\" + arquivo);
                string data = fileCreateDate + "";
                string datahora="";
                //tirando os caracteres especiais da hora e data.
                data = data.Replace("/", "");
                data = data.Replace(":", "");
                datahora = data.Substring(0, 2) + "-" + data.Substring(2, 2) + "-" + data.Substring(4, 2) + "  " + data.Substring(9, 2) + "h " + data.Substring(11, 2) + "m " + data.Substring(13, 2)+"s";
                data = data.Substring(0, 2) + "-" + data.Substring(2, 2) + "-" + data.Substring(4, 4);
                if (qual == "DE CRIAÇÃO: DD-MM-AAAA")
                {
                    //verifica se o arquivo existe
                    if (System.IO.File.Exists(caminho + @"\" + data + tipo))
                    {
                        int cont=0;
                        while(System.IO.File.Exists(caminho + @"\" + data + " [" +cont+ "]" + tipo))
                        {
                            cont++;
                        }
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + data + " [" + cont + "]" + tipo);
                        return true;

                    }
                    else
                    {
                        //aplicando o renome.
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + data + tipo);
                        return true;
                    }
                }
                else
                {
                    if (System.IO.File.Exists(caminho + @"\" + datahora + tipo))
                    {
                        int cont = 0;
                        while (System.IO.File.Exists(caminho + @"\" + datahora + " [" + cont + "]" + tipo))
                        {
                            cont++;
                        }
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + datahora + " [" + cont + "]" + tipo);
                        return true;
                    }
                    else
                    {
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + datahora + tipo);
                        return true;
                    }
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
