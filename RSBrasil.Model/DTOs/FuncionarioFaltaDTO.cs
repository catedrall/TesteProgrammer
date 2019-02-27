using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Model.DTOs
{
    public class FuncionarioFaltaDTO
    {
        public int idFunc { get; set; }
        public int idFalta { get; set; }
        public string NomeFuncionario { get; set; }
        public DateTime DataFalta { get; set; }
    }
}
