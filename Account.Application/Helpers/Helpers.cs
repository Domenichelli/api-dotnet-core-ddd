using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Application.Helpers
{
    public static class Helpers
    {
        /// <summary>
        /// Verifica se o CPF é válido.
        /// </summary>
        /// <param name="cpf">string cpf</param>
        /// <returns>bool</returns>
        public static bool IsCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || !long.TryParse(cpf, out long isCpf))
                return false;

            if (cpf == "00000000000" || cpf == "11111111111" ||
                cpf == "22222222222" || cpf == "33333333333" ||
                cpf == "44444444444" || cpf == "55555555555" ||
                cpf == "66666666666" || cpf == "77777777777" ||
                cpf == "88888888888" || cpf == "99999999999")
                return false;


            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Validação simplificadade Agencia
        /// </summary>
        /// <param name="agency">string agency</param>
        /// <returns>bool</returns>
        public static bool IsAgency(string agency)
        {
            if (string.IsNullOrEmpty(agency) || !long.TryParse(agency, out long IsAgency))
                return false;

            if (agency.Length < 4 || agency.Length > 4)
                return false;

            if (agency == "0000" || agency == "1111" ||
                agency == "2222" || agency == "3333" ||
                agency == "4444" || agency == "5555" ||
                agency == "6666" || agency == "7777" ||
                agency == "8888" || agency == "9999")
                return false;

            return true;
        }

        /// <summary>
        /// Validação simplificadade Agencia
        /// </summary>
        /// <param name="account">string agency</param>
        /// <returns>bool</returns>
        public static bool IsAccount(string account)
        {
            var retorno = false;

            if (string.IsNullOrEmpty(account) || !long.TryParse(account, out long IsAgency))
                return false;

            if (account.Length < 5 || account.Length > 10)
                return false;

            for (int i = 0; i < account.Length; i++)
            {
                if(account[0] != account[i])
                    retorno = true;
            }
            
            return retorno;
        }

        
    }
}
