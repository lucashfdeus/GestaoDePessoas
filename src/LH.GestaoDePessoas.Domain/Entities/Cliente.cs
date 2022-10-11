using LH.GestaoDePessoas.Domain.Validation.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace LH.GestaoDePessoas.Domain.Entities
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            DataCadastro = new DateTime();
            Enderecos = new List<Endereco>();
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

        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
