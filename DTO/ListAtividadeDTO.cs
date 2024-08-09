using ListaAtividades.Domain;
using ListaAtividades.Services.Interfaces;

namespace ListaAtividades.DTO
{
    public class ListAtividadeDTO
    {
        public string Nome { get; set; }
        public List<Atividade> Atividades { get; set; }
    }
}
