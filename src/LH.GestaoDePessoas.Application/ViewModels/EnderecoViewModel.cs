using System.ComponentModel.DataAnnotations;

namespace LH.GestaoDePessoas.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [ScaffoldColumn(false)]
        public int ClienteId { get; set; }
    }
}
