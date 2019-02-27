using RSBrasil.Shared.Model;
using System;

namespace RSBrasil.Model.Entidades
{
    public class TipoAfastamentos : ModelBase
    {
        public TipoAfastamentos()
        {

        }

        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? Duracao { get; set; }
    }
}
