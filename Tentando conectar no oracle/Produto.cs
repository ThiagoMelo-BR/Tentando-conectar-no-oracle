using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tentando_conectar_no_oracle
{
    //[Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime ?DataRegistro { get; set; }
    }
}
