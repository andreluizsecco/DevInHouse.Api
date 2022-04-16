using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AlunosController : ControllerBase
    {
        /// <summary>
        /// Retorna uma lista de alunos baseado no filtro
        /// </summary>
        /// <param name="nome">filtro por nome</param>
        /// <returns>Retorna uma lista de alunos</returns>
        /// <response code="200">Retorna os alunos</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(List<Aluno>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<List<Aluno>> ObterAlunos(string? nome)
        {
            var lista = new List<Aluno>();
            var aluno = new Aluno(1, "André", "Secco", new DateTime(1991, 05, 25));
            var aluno2 = new Aluno(2, "João", "Secco", new DateTime(1988, 06, 24));
            var aluno3 = new Aluno(3, "Paulo", "Secco", new DateTime(1983, 11, 08));

            lista.Add(aluno);
            lista.Add(aluno2);
            lista.Add(aluno3);

            if (!string.IsNullOrWhiteSpace(nome))
            {
                var listaFiltrada = lista.Where(l => l.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase));
                return Ok(listaFiltrada);
            }
            
            // Se um erro ocorresse, poderia ser retornada a linha abaixo
            //return StatusCode(StatusCodes.Status500InternalServerError, new { mensagem = "Erro desconhecido" });

            return Ok(lista);
        }
        
        /// <summary>
        /// Retorna o aluno baseado em seu código
        /// </summary>
        /// <param name="codigo">Código do aluno</param>
        /// <returns>Retorna o aluno</returns>
        /// <response code="200">Retorna o aluno</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{codigo}")]
        public ActionResult<Aluno> ObterAluno(int codigo)
        {
            // Simulando a obtenção do aluno do banco de dados
            var aluno = new Aluno(codigo, "André", "Secco", new DateTime(1991, 05, 25));
            
            return Ok(aluno);
        }

        /// <summary>
        /// Cria um aluno
        /// </summary>
        /// <param name="aluno">Dados do Aluno</param>
        /// <returns>Retorna o código do aluno criado</returns>
        /// <response code="201">Retorna o código do aluno criado</response>
        /// <response code="400">Retorna erros de validação</response>
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult CriarAluno(Aluno aluno)
        {
            //Simulando que estou criando um aluno no banco de dados
            return CreatedAtAction(nameof(ObterAluno), new { codigo = aluno.Codigo }, aluno.Codigo);
        }

        /// <summary>
        /// Atualiza um aluno
        /// </summary>
        /// <param name="aluno">Dados do Aluno</param>
        /// <returns></returns>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult AtualizarAluno(Aluno aluno)
        {
            //Simulando que estou atualizando um aluno no banco de dados
            
            // Se um erro ocorresse, poderia ser retornada a linha abaixo
            //return StatusCode(StatusCodes.Status500InternalServerError, new { mensagem = "Erro desconhecido" });

            // Outra forma de retornar o status code
            //return StatusCode(StatusCodes.Status204NoContent);
            return NoContent();
        }

        /// <summary>
        /// Exclui um aluno pelo código
        /// </summary>
        /// <param name="codigo">Código do Aluno</param>
        /// <returns></returns>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public ActionResult ExcluirAluno(int codigo)
        {
            //Simulando que estou excluindo um aluno no banco de dados

            //Simulando um erro de servidor caso a condição abaixo seja atendida
            if (codigo == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensagem = "Erro desconhecido" });

            // Outra forma de retornar o status code
            //return StatusCode(StatusCodes.Status204NoContent);
            return NoContent();
        }
    }
}