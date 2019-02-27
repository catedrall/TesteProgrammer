using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace RSBrasil.Model.DTOs
{
    public class TipoAfastamentosDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data início")]
        public string DataInicio { get; set; }
        [Display(Name = "Data fim")]
        public string DataFim { get; set; }
        [Display(Name = "Duração")]
        public int? Duracao { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.Descricao, "Descricao", "Descricao é obrigatória")
                .IsNotNullOrEmpty(this.DataInicio, "DataInicio", "Data início é obrigatória")
            );
        }
    }
}
