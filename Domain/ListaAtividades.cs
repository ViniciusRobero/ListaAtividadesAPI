using ListaAtividades.Services.Interfaces;

namespace ListaAtividades.Domain
{
    public class ListaAtividades<T> where T : IAtividade
    {
        public string Nome { get; private set; }
        private List<T> atividades;

        public ListaAtividades(string nome)
        {
            Nome = nome;
            atividades = new List<T>();
        }

        public void AdicionarAtividade(T atividade)
        {
            atividades.Add(atividade);
        }

        public void AdicionarAtividades(List<T> atividade)
        {
            atividades.AddRange(atividade);
        }

        public void RemoverAtividade(int id)
        {
            var atividade = atividades.FirstOrDefault(a => a.Id == id);
            if (atividade != null)
            {
                atividades.Remove(atividade);
            }
        }

        public IEnumerable<T> ListarAtividades()
        {
            return atividades;
        }
    }

}
