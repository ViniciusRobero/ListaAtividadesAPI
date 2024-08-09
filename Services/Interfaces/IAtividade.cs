namespace ListaAtividades.Services.Interfaces
{
    public interface IAtividade
    {
        int Id { get; set; }
        string Nome { get; set; }
        bool IsConcluida { get; set; }

        void Concluir();
    }
}
