using System.ComponentModel.DataAnnotations;

namespace MinhaApi
{
    public class Aluno
    {
        public Aluno(int codigo, string nome, string sobrenome, DateTime dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Codigo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} tem que ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}