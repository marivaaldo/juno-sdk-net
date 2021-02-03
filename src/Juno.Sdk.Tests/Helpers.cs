using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Tests
{
    public static class Helpers
    {
        public static JunoClient CreateClient(bool authenticate = true)
        {
            var credentials = new Credentials
            {
                ClientId = "",
                ClientSecret = "",
                PrivateToken = "",
                PublicToken = "",
                ReferralToken = ""
            };

            var client = new JunoClient(credentials, SandboxEnvironment.Instance);

            if (authenticate)
            {
                client.Authenticate();
            }

            return client;
        }

        public static string NewCPF()
        {
            var random = new Random();

            int sum = 0;
            int[] multiples = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string newCPF;

            do
            {
                newCPF = random.Next(1, 999999999).ToString().PadLeft(9, '0');
            }
            while (
                newCPF == "000000000"
                || newCPF == "111111111"
                || newCPF == "222222222"
                || newCPF == "333333333"
                || newCPF == "444444444"
                || newCPF == "555555555"
                || newCPF == "666666666"
                || newCPF == "777777777"
                || newCPF == "888888888"
                || newCPF == "999999999"
            );

            for (int i = 1; i < multiples.Length; i++)
                sum += int.Parse(newCPF[i - 1].ToString()) * multiples[i];

            int rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            newCPF += rest;
            sum = 0;

            for (int i = 0; i < multiples.Length; i++)
                sum += int.Parse(newCPF[i].ToString()) * multiples[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            newCPF += rest;

            return newCPF;

        }

        public static string NewCNPJ()
        {
            int firstDigit = 0, secondDigit = 0, rest = 0;
            string nDigResult;
            string numerosContatenados;
            string numeroGerado;

            Random randomRumber = new Random();

            //
            // Generated Numbers

            int n1 = randomRumber.Next(10);
            int n2 = randomRumber.Next(10);
            int n3 = randomRumber.Next(10);
            int n4 = randomRumber.Next(10);
            int n5 = randomRumber.Next(10);
            int n6 = randomRumber.Next(10);
            int n7 = randomRumber.Next(10);
            int n8 = randomRumber.Next(10);
            int n9 = randomRumber.Next(10);
            int n10 = randomRumber.Next(10);
            int n11 = randomRumber.Next(10);
            int n12 = randomRumber.Next(10);

            int sum = n12 * 2 + n11 * 3 + n10 * 4 + n9 * 5 + n8 * 6 + n7 * 7 + n6 * 8 + n5 * 9 + n4 * 2 + n3 * 3 + n2 * 4 + n1 * 5;
            int value = (sum / 11) * 11;

            firstDigit = sum - value;

            //
            // Primeiro resto da divisão por 11.

            rest = (firstDigit % 11);

            if (firstDigit < 2)
            {
                firstDigit = 0;
            }
            else
            {
                firstDigit = 11 - rest;
            }

            int soma2 = firstDigit * 2 + n12 * 3 + n11 * 4 + n10 * 5 + n9 * 6 + n8 * 7 + n7 * 8 + n6 * 9 + n5 * 2 + n4 * 3 + n3 * 4 + n2 * 5 + n1 * 6;

            int valor2 = (soma2 / 11) * 11;

            secondDigit = soma2 - valor2;

            //
            //Primeiro resto da divisão por 11.

            rest = (secondDigit % 11);

            if (secondDigit < 2)
            {
                secondDigit = 0;
            }
            else
            {
                secondDigit = 11 - rest;
            }

            //Conctenando os numeros

            numerosContatenados = $"{n1}{n2}{n3}{n4}{n5}{n6}{n7}{n8}{n9}{n10}{n11}{n12}";

            //Concatenando o primeiro resto com o segundo.
            nDigResult = $"{firstDigit}{secondDigit}";

            numeroGerado = numerosContatenados + nDigResult;

            return numeroGerado;
        }
    }
}
