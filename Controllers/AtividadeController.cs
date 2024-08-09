using ListaAtividades.Services.Interfaces;
using ListaAtividades.Services;
using Microsoft.AspNetCore.Mvc;
using ListaAtividades.Domain;
using ListaAtividades.DTO;

namespace ListaAtividades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadesController : ControllerBase
    {
        private readonly ServicoGerenciamentoAtividades<IAtividade> _servico;

        public AtividadesController(ServicoGerenciamentoAtividades<IAtividade> servico)
        {
            _servico = servico;
        }

        [HttpGet("{nomeLista}")]
        public IActionResult GetAtividades(string nomeLista)
        {
            var atividades = _servico.ExibirAtividades(nomeLista);
            return Ok(atividades);
        }
        [HttpGet]
        public IActionResult GetTodasAtividades()
        {
            var atividades = _servico.ExibirListas();
            return Ok(atividades);
        }

        [HttpPost]
        public IActionResult AdicionarLista([FromBody] ListAtividadeDTO atividade)
        {
            _servico.AdicionarLista(atividade);
            return Created();
        }

        [HttpPut("ConcluirAtividade")]
        public IActionResult ConcluirAtividade(string nomeLista, int idAtividade)
        {
            _servico.MarcarAtividadeConcluida(nomeLista, idAtividade);
            return Ok();
        }

        [HttpDelete("{nomeAtividade}")]
        public IActionResult RemoverAtividade(string nomeAtividade)
        {
            _servico.RemoverListAtividade(nomeAtividade);
            return Ok();
        }
    }

}
