using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace RSBrasil.Model.DTOs
{
    public class HistoricoBeneficiosDTO : Notifiable, ICommand
    {
        public int Id { get; set; }

        [Display(Name = "Data Pagamento")]
        public string DataPagamento { get; set; }
        
        [Display(Name = "Funcionário")]
        public int IdFuncionario { get; set; }

        [Display(Name = "Benefícios")]
        public int IdTipoBeneficio { get; set; }

        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.DataPagamento, "DataPagamento", "Data de pagamento obrigatória")
                .IsNotNullOrEmpty(this.IdFuncionario.ToString(), "IdFuncionario", "Funcionário é obrigatório")
                .IsNotNullOrEmpty(this.IdTipoBeneficio.ToString(), "IdTipoBeneficio", "Beneficio é obrigatório")
            );
        }
    }
}
