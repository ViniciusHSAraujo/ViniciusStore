using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViniciusStore.Domain.StoreContext.ValueObjects {
    public class Document : Notifiable, IValidatable {
        public Document(string number) {
            Number = number;

            Validate();
        }

        public string Number { get; set; }

        public void Validate() {
            AddNotifications(new Contract()
                .IsTrue(IsCpf(Number), "Number", "CPF inválido."));
        }

        public static bool IsCpf(string cpf) {
            int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
            string[] invalidos = new string[] {
                "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666",
                "77777777777", "88888888888", "99999999999"
            };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            if (invalidos.Any(invalido => cpf.Equals(invalido))) {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}