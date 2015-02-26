using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Pim.Models
{
    public class Pedido
    {

        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public string ClienteId { get; set; }

        [Display(Name = "Pedido")]
        public string Produto { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public DateTime DataRegistro { get; set; }

        public string Endereco { get; set; }
        //public Cliente Clientes { get; set; }
    }
}