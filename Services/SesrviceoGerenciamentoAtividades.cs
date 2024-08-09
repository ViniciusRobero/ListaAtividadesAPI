using ListaAtividades.Domain;
using ListaAtividades.DTO;
using ListaAtividades.Services.Interfaces;

namespace ListaAtividades.Services
{
    public class ServicoGerenciamentoAtividades<T> where T : IAtividade
    {
        private readonly Dictionary<string, ListaAtividades<T>> listasAtividades;

        public ServicoGerenciamentoAtividades()
        {
            listasAtividades = new Dictionary<string, ListaAtividades<T>>();
        }


        public void AdicionarLista(ListAtividadeDTO atividadeDTO)
        {
            if (!listasAtividades.ContainsKey(atividadeDTO.Nome))
            {
                var listaAtividades = new ListaAtividades<T>(atividadeDTO.Nome);

                foreach (var atividade in atividadeDTO.Atividades)
                {
                    if (atividade is T castedAtividade)
                    {
                        listaAtividades.AdicionarAtividade(castedAtividade);
                    }
                }

                listasAtividades[atividadeDTO.Nome] = listaAtividades;
            }
        }

        public void MarcarAtividadeConcluida(string nomeLista, int idAtividade)
        {
            if (listasAtividades.ContainsKey(nomeLista))
            {
                var lista = listasAtividades[nomeLista];
                var atividade = lista.ListarAtividades().FirstOrDefault(a => a.Id == idAtividade);
                if (atividade != null)
                {
                    atividade.Concluir();
                }
            }
        }

        public IEnumerable<string> ExibirListas()
        {
            foreach (var lista in listasAtividades)
            {
                yield return lista.Key;
            }
        }

        public IEnumerable<T> ExibirAtividades(string nomeLista)
        {
            if (listasAtividades.ContainsKey(nomeLista))
            {
                return listasAtividades[nomeLista].ListarAtividades();
            }
            return new List<T>();
        }

        public void RemoverListAtividade(string nome)
        {
            listasAtividades.Remove(nome);
        }
    }
}
