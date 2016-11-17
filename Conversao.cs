using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculdade___Linguagens_Formais_e_Autômatos
{
    class Conversao
    {
        public static string InverterString(string str)
        {
            int tamanho = str.Length;

            char[] caracteres = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                caracteres[i] = str[tamanho - 1 - i];
            }

            return new string(caracteres);
        }
        public static string DecimalParaBinario(string numero)
        {

            string valor = "";

            int dividendo = Convert.ToInt32(numero);

            if (dividendo == 0 || dividendo == 1)
            {

                return Convert.ToString(dividendo);

            }

            else
            {

                while (dividendo > 0)
                {

                    valor += Convert.ToString(dividendo % 2);

                    dividendo = dividendo / 2;

                }

                return InverterString(valor);

            }

        }
        public static int CharToNum(char letra)
        {
            // não aceitar a conversão para o mesmo número do delimitador.
            /*
            int result = 16;

            var inicio = ' ';

            while (result < 128)
            {

                inicio++;
                result++;

                if (inicio == letra)
                    break;

            }

            return result;
            */
            int result = 0;

            if (Char.IsDigit(letra))
            {
                result = int.Parse(letra.ToString());
                return result;
            }
            else
            {
                var inicio = 'a';
                result = 10;

                while (result != letra)
                { 
                    inicio++;
                    result++;
                }

                // valores do simbolo branco e delimitador.
                if (result == 99
                    || result == 100)
                    result++;

                return result;
            }
        }

    }
}

