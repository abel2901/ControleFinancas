﻿using ControleFinancas.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleFinancas.Dtos
{
    public class CreateDespesaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public int TipoCategoria { get; set; }
    }
}
