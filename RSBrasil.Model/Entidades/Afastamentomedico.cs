using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Model.Entidades
{
    public class AfastamentoMedico : ModelBase
    {
        public AfastamentoMedico()
        {

        }

        public string Descricao { get; set; }
        public DateTime? DataFimAfastamento { get; set; }
        public DateTime? DataInicioAfastamento { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdTipoAfastamento { get; set; }
    }
}
