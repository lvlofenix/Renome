﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_aleatorio
    {
        public Boolean renome_aleatorio(string caminho, string arquivo, string tipo, string qual)
        {
            string erro = "";
            try
            {
                Random rd = new Random();
                //aplicando o renome.
                if (qual == "NUMEROS")
                {
                    char[] chars = new char[9];
                    chars = "0123456789".ToCharArray();
                    string numero = "";
                    for (int i = 0; i < rd.Next(4, 20); i++)
                    {
                        numero = numero + chars[rd.Next(0, 9)];
                    }
                    if (System.IO.File.Exists(caminho + @"\" + numero + tipo))
                    {
                        while (System.IO.File.Exists(caminho + @"\" + numero + tipo))
                        {
                            numero = chars[rd.Next(0, 9)]+chars[rd.Next(0, 9)]+chars[rd.Next(0, 9)]+chars[rd.Next(0, 9)]+chars[rd.Next(0, 9)]+chars[rd.Next(0, 9)]+"";
                        }
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + numero + tipo);
                    return true;
                    }
                    else 
                    {
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + numero + tipo);
                    return true;
                    }

                }
                else if (qual == "LETRAS")
                {
                    char[] chars = new char[52];
                    chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                    string nome = "";
                    for (int i = 0; i < rd.Next(5, 25); i++)
                    {
                        nome = nome + chars[rd.Next(0, 52)];
                    }
                    if (System.IO.File.Exists(caminho + @"\" + nome + tipo))
                    {
                        while (System.IO.File.Exists(caminho + @"\" + nome + tipo))
                        {
                            nome = chars[rd.Next(0, 52)] + chars[rd.Next(0, 52)] + chars[rd.Next(0, 52)] + chars[rd.Next(0, 52)] + chars[rd.Next(0, 52)] + chars[rd.Next(0, 52)]+chars[rd.Next(0, 52)]+"";
                        }
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + tipo);
                        return true;
                    }
                    else
                    {
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + tipo);
                        return true;
                    }
                }
                else if (qual == "NUMEROS E LETRAS")
                {
                    char[] chars = new char[56];
                    chars = "456abcdefgim5Nnopq789rsuvwxyzABCD0EFGH35IJKLMSTUVWXYZ123".ToCharArray();
                    string nome = "";
                    for (int i = 0; i < rd.Next(5, 25); i++)
                    {
                        nome = nome + chars[rd.Next(0, 56)];
                    }
                    if (System.IO.File.Exists(caminho + @"\" + nome + tipo))
                    {
                        while (System.IO.File.Exists(caminho + @"\" + nome + tipo))
                        {
                            nome = chars[rd.Next(0, 56)] + chars[rd.Next(0, 56)] + chars[rd.Next(0, 56)] + chars[rd.Next(0, 56)] + chars[rd.Next(0, 56)] + chars[rd.Next(0, 56)] + chars[rd.Next(0, 56)]+"";
                        }
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + tipo);
                        return true;
                    }
                    else
                    {
                        File.Move(caminho + @"\" + arquivo, caminho + @"\" + nome + tipo);
                        return true;
                    }
                }
                else
                {
                    erro = "Não foi possivel identificar a solicitação para o arquivo: " + caminho + @"\" + arquivo;
                    return false;
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