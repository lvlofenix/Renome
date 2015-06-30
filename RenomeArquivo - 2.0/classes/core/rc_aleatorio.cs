using System;
using System.Text;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class rc_aleatorio
    {
        public string erro = "";
        public Boolean renome_aleatorio(string caminho, string arquivo, string tipo, string qual)
        {
            string novonome=null;
            try
            {
                Random rd = new Random();
                //aplicando o renome.
                if (qual == "NUMEROS")
                {
                    char[] chars = new char[9];
                    chars = "0123456789".ToCharArray();
                    for (int i = 0; i < rd.Next(4, 20); i++)
                    {
                        novonome = novonome + chars[rd.Next(0, 9)];
                    }
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + novonome + tipo);
                    return true;

                }
                else if (qual == "LETRAS")
                {
                    char[] chars = new char[52];
                    chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                    for (int i = 0; i < rd.Next(5, 25); i++)
                    {
                        novonome = novonome + chars[rd.Next(0, 52)];
                    }
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + novonome + tipo);
                    return true;
                }
                else if (qual == "NUMEROS E LETRAS")
                {
                    char[] chars = new char[56];
                    chars = "456abcdefgim5Nnopq789rsuvwxyzABCD0EFGH35IJKLMSTUVWXYZ123".ToCharArray();
                    for (int i = 0; i < rd.Next(5, 25); i++)
                    {
                        novonome = novonome + chars[rd.Next(0, 56)];
                    }
                    File.Move(caminho + @"\" + arquivo, caminho + @"\" + novonome + tipo);
                    return true;
                }
                else
                {
                    return false;
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
