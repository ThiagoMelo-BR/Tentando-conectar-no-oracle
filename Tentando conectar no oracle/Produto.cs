using System;
using System.ComponentModel.DataAnnotations;

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
