using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_tipo
    {
        string erro = "";
        public Boolean renome_tipo(string caminho, string arquivo,string qual, string tipo)
        {
            //aplicando o renome.
            try
            {
                if (qual == "COMPLETO")
                {
                    if (tipo == ".txt" || tipo == ".doc" || tipo == ".docx")
                    {
                        if (System.IO.File.Exists(caminho + @"\" + "DOCUMENTO" + tipo))
                        {
                            int cont = 0;
                            while (System.IO.File.Exists(caminho + @"\" + "DOCUMENTO" + " [" + cont + "]" + tipo))
                            {
                                cont++;
                            }
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "DOCUMENTO" + " [" + cont + "]" + tipo);
                            return true;
                        }
                        else
                        {
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "DOCUMENTO" + tipo);
                            return true;
                        }
                    }
                    else if (tipo == ".png" || tipo == ".jpg" || tipo == ".bitmap" || tipo == ".gif" || tipo == ".bmp")
                    {
                        if (System.IO.File.Exists(caminho + @"\" + "IMAGEM" + tipo))
                        {
                            int cont = 0;
                            while (System.IO.File.Exists(caminho + @"\" + "IMAGEM" + " [" + cont + "]" + tipo))
                            {
                                cont++;
                            }
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "IMAGEM" + " [" + cont + "]" + tipo);
                            return true;
                        }
                        else
                        {
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "IMAGEM" + tipo);
                            return true;
                        }
                    }
                    else if (tipo == ".MP3" || tipo == ".WAV" || tipo == ".M4A")
                    {
                        if (System.IO.File.Exists(caminho + @"\" + "AUDIO" + tipo))
                        {
                            int cont = 0;
                            while (System.IO.File.Exists(caminho + @"\" + "AUDIO" + " [" + cont + "]" + tipo))
                            {
                                cont++;
                            }
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "AUDIO" + " [" + cont + "]" + tipo);
                            return true;
                        }
                        else
                        {
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "AUDIO" + tipo);
                            return true;
                        }
                    }
                    else if (tipo == ".AVI" || tipo == ".MP4" || tipo == ".RMVB" || tipo == ".flv")
                    {
                        if (System.IO.File.Exists(caminho + @"\" + "VIDEO" + tipo))
                        {
                            int cont = 0;
                            while (System.IO.File.Exists(caminho + @"\" + "VIDEO" + " [" + cont + "]" + tipo))
                            {
                                cont++;
                            }
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "VIDEO" + " [" + cont + "]" + tipo);
                            return true;
                        }
                        else
                        {
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "VIDEO" + tipo);
                            return true;
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(caminho + @"\" + "ARQUIVO" + tipo))
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
                            File.Move(caminho + @"\" + arquivo, caminho + @"\" + "ARQUIVO" + tipo);
                            return true;
                        }
                    }
                }
                else
                {
                    if (System.IO.File.Exists(caminho + @"\" + tipo.Replace(".", "") + tipo))
                    {
                        int cont = 0;
                        while (System.IO.File.Exists(caminho + @"\" + tipo.Replace(".", "") + " [" + cont + "]" + tipo))
                        {
                            cont++;
                        }
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + tipo.Replace(".","") + " [" + cont + "]" + tipo);
                        return true;
                    }
                    else
                    {
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + tipo.Replace(".", "") + tipo);
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
