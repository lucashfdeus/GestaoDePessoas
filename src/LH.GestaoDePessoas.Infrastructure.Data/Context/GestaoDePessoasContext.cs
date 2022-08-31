using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Infrastructure.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace LH.GestaoDePessoas.Infrastructure.Data.Context
{
    public class GestaoDePessoasContext : DbContext
    {
        public GestaoDePessoasContext() : base("DefaultConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configurando migrations.
            //Remove a numenclatura automatica como plural, remove delete cascade.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges() 
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null) )
            {
                if (entry.State == EntityState.Added) 
                {
                    entry.Property("DataCadastro").CurrentValue = System.DateTime.Now;
                }

                if (entry.State == EntityState.Modified) {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();  
        }
    }
}
