using System;

namespace SubirNotaWPF.MiComponente
{
    internal class LogicaEncriptacion
    {
        static string abc = "abcdefghijklmñnopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890_-+,#$%&/()=¿?¡!|,.;:{}[]";
        public static string encriptar(string texto, string tipo_encriptacion, string clave)
        {
            switch (tipo_encriptacion)
            {
                case "cesar":
                    try
                    {
                        int clave_int = Convert.ToInt32(clave);
                        return cesar_enc(texto, clave_int);
                    }
                    catch (Exception ex) { return "clave no valida"; }
                    break;
                default:
                    return "tipo de encriptacion no valido";
            }

        }

        public static string desencriptar(string texto, string tipo_encriptacion, string clave)
        {
            switch (tipo_encriptacion)
            {
                case "cesar":
                    try
                    {
                        int clave_int = Convert.ToInt32(clave);
                        return cesar_dec(texto, clave_int);
                    }
                    catch (Exception ex) { return "clave no valida"; }
                    break;
                default:
                    return "tipo de desencriptacion no valido";
            }
        }

        static string cesar_enc(string mensaje, int desplazamiento)
        {
            String cifrado = "";
            desplazamiento = desplazamiento % abc.Length;

            for (int i = 0; i < mensaje.Length; i++)
            {
                int posCaracter = getPosABC(mensaje[i]);
                if (posCaracter != -1)
                {
                    int pos = (posCaracter + desplazamiento) % abc.Length;
                    cifrado += abc[pos];
                }
                else
                {
                    cifrado += mensaje[i];
                }
            }


            return cifrado;
        }

        static string cesar_dec(string mensaje, int desplazamiento)
        {
            String cifrado = "";
            desplazamiento = desplazamiento % abc.Length;
            for (int i = 0; i < mensaje.Length; i++)
            {
                int posCaracter = getPosABC(mensaje[i]);
                if (posCaracter != -1) //el caracter existe en la variable abc
                {
                    int pos = (posCaracter + (abc.Length - desplazamiento)) % abc.Length;
                    cifrado += abc[pos];
                }
                else
                {
                    cifrado += mensaje[i];
                }
            }
            return cifrado;
        }

        static int getPosABC(char caracter)
        {
            for (int i = 0; i < abc.Length; i++)
            {
                if (caracter == abc[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
