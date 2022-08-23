﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH.GestaoDePessoas.Domain.Entities
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            DataCadastro = new DateTime();
        }

        //public Cliente()
        //{
        //    ClienteId = Guid.NewGuid();
        //}
        //public Guid ClienteId { get; set; }

        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}