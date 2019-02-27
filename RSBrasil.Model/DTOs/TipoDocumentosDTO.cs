﻿using Flunt.Notifications;
using Flunt.Validations;
using RSBrasil.Model.Interface.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace RSBrasil.Model.DTOs
{
    public class TipoDocumentosDTO : Notifiable, ICommand
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(this.Descricao, "Descricao", "Descricao é obrigatória")
            );
        }
    }
}
