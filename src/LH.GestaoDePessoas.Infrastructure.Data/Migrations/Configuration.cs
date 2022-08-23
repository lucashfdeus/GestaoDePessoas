using System.Data.Entity.Migrations;

namespace LH.GestaoDePessoas.Infrastructure.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LH.GestaoDePessoas.Infrastructure.Data.Context.GestaoDePessoasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LH.GestaoDePessoas.Infrastructure.Data.Context.GestaoDePessoasContext context)
        {
            
        }
    }
}
