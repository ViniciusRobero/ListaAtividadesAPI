using ListaAtividades.Services.Interfaces;

namespace ListaAtividades.Domain
{
    public class Atividade : IAtividade
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public bool IsConcluida {get; set;}

        public void Concluir()
        {
            IsConcluida = true;
        }
    }
}
