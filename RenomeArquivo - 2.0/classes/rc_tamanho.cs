using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_tamanho
    {
        public Boolean renome_tamanho(string caminho, string arquivo, string tipo, string qual)
        {
            string erro = "";
            try
            {
                string peso = new FileInfo(caminho + @"\" + arquivo).Length + "";
                if (qual == "POR KB'S")
                {
                    //aplicando o renome.
                    peso = Convert.ToInt64(peso) / 1024 + "";
                    if (System.IO.File.Exists(caminho + @"\" + peso + tipo))
                    {
                        int cont = 0;
                        while (System.IO.File.Exists(caminho + @"\" + peso + " [" + cont + "]" + tipo))
                        {
                            cont++;
                        }
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + " [" + cont + "]" + tipo);
                        return true;
                    }
                    else
                    {
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + tipo);
                        return true;
                    }

                }
                else
                {
                    if (Convert.ToInt32(peso) < 1024)
                    {
                        peso = (Convert.ToDouble(peso) / 1024) / 1024 + "";
                        if (System.IO.File.Exists(caminho + @"\" + peso + tipo))
                        {
                            int cont = 0;
                            while (System.IO.File.Exists(caminho + @"\" + peso + " [" + cont + "]" + tipo))
                            {
                                cont++;
                            }
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + " [" + cont + "]" + tipo);
                        }
                        else
                        {
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + tipo);
                        }
                    }
                    else
                    {
                        peso = (Convert.ToInt64(peso) / 1024f) / 1024f + "";
                        if (System.IO.File.Exists(caminho + @"\" + peso + tipo))
                        {
                            int cont = 0;
                            while (System.IO.File.Exists(caminho + @"\" + peso + " [" + cont + "]" + tipo))
                            {
                                cont++;

                            }
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + " [" + cont + "]" + tipo);
                        }
                        else
                        {
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + peso + tipo);
                        }
                    }
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
