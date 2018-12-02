namespace Nucleo.Compartilhado.Comum.Dominio
{
    public class Identidade : ObjetoDeValor<Identidade>
    {
        public int Id { get; private set; }

        // Foi decidido que a estratégia para geração dos ID's deve ser pelo mecanismo do banco de dados.
        // Necessidade para uso do ORM
        protected Identidade() { }
    }
}
