using LH.GestaoDePessoas.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace LH.GestaoDePessoas.Infrastructure.Data.EntityConfig
{
    //FLUENT API
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired();

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute() { IsUnique = true}));

            Property(c => c.Email)
                .IsOptional();

            Property(c => c.DataNascimento)
                .IsOptional();

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();


            ToTable("Clientes");

        }
    }
}
