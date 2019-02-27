using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSBrasil.Model.DTOs
{
    public class FuncionarioDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        [Display(Name = "Carteira de motorista")]
        public string CarteiraMotorista { get; set; }

        [Display(Name = "Carteira de trabalho")]
        public string CarteiraTrabalho { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Date nascimento")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DataNascimento { get; set; }

        [Display(Name = "Data admissão")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string DataAdmissao { get; set; }

        public bool Ativo { get; set; }
        public int Sexo { get; set; }

        [Display(Name = "Estado civil")]
        public int EstadoCivil { get; set; }

        [Display(Name = "Raça")]
        public int RacaCor { get; set; }

        [Display(Name = "Nome pai")]
        public string NomePai { get; set; }

        [Display(Name = "Nome mãe")]
        public string NomeMae { get; set; }
        public string Nacionalidade { get; set; }
        public int NacionalidadeUf { get; set; }
        public int Escolaridade { get; set; }

        [Display(Name = "Deficiência")]
        public bool Deficiencia { get; set; }

        [Display(Name = "Deficiência observação")]
        public string DeficienciaObservacao { get; set; }
        public string Banco { get; set; }

        [Display(Name = "Tipo conta")]
        public int TipoConta { get; set; }

        [Display(Name = "Número agência")]
        public string NumeroAgencia { get; set; }

        [Display(Name = "Número conta")]
        public string NumeroConta { get; set; }

        [Display(Name = "Última férias início")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string UltimoPeriodoFeriasInicio { get; set; }

        [Display(Name = "Última férias fim")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string UltimoPeriodoFeriasFim { get; set; }

        [Display(Name = "Ferias gozadas")]
        public int FeriasGozadas { get; set; }

        [Display(Name = "Ferias a gozar")]
        public int FeriasGozar { get; set; }

        [Display(Name = "Data limite férias")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string DataLimiteFerias { get; set; }
        public int IdFuncionarioDocumento { get; set; }
        public int IdCargo { get; set; }
        public int IdEndereco { get; set; }
        public int IdFuncionario { get; set; }
        public int IdPerfilAcesso { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string UF { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.CarteiraMotorista, "CarteiraMotorista", "CNH é obrigatória")
                .IsNotNullOrEmpty(this.CarteiraTrabalho, "CarteiraTrabalho", "Carteira de trabalho é obrigatória")
                .IsNotNullOrEmpty(this.CPF, "CPF", "CPF é obrigatório")
                .IsTrue(ValidaCpf(), "CPF", "Digite um CPF válido")
                .IsNotNullOrEmpty(this.Login, "Login", "Login é obrigatório")
                .HasMinLen(this.Login, 6, "Login", "O login não pode ter menos que 6 caracteres")
                .HasMaxLen(this.Login, 20, "Login", "O login não pode ter mais que 20 caracteres")
                .IsNull(Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(this.RG, "RG", "RG é obrigatório")
                .IsNotNullOrEmpty(this.Senha, "Senha", "Senha é obrigatória")
                .HasMinLen(this.Login, 8, "Senha", "O senha não pode ter menos que 8 caracteres")
                .HasMaxLen(this.Login, 20, "Senha", "O senha não pode ter mais que 20 caracteres")
                .IsNotNullOrEmpty(this.DataNascimento.ToString(), "DataNascimento", "Data de nascimento é obrigatória")
                .IsNotNullOrEmpty(this.Cep, "Cep", "Cep é obrigatória")
                .HasMinLen(this.Cep, 8, "Cep", "Cep inválido")
                .IsNotNullOrEmpty(this.Logradouro, "Logradouro", "Logradouro é obrigatória")
                .IsNotNullOrEmpty(this.Numero, "Numero", "Numero é obrigatória")
                .IsNotNullOrEmpty(this.Bairro, "Bairro", "Bairro é obrigatória")
                .IsNotNullOrEmpty(this.Cidade, "Cidade", "Cidade é obrigatória")
                //.IsNotNullOrEmpty(this.NacionalidadeUf, "UF", "Estado é obrigatória")
            );
        }

        public bool ValidaCpf()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            tempCpf = CPF.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }
    }
}
