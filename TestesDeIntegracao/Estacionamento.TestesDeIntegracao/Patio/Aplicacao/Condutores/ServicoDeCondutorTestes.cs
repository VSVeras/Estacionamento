using NHibernate;
using Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia;
using Nucleo.Compartilhado.Dominio.Condutores;
using Nucleo.Compartilhado.Dominio.Veiculos;
using Patio.Aplicacao.Condutores;
using Patio.Dominio.Tickets;
using Patio.Infraestrutura.Repositorios;
using System;
using Xunit;

namespace Estacionamento.TestesDeIntegracao.Patio.Aplicacao.Condutores
{
    public sealed class ServicoDeCondutorTestes : IDisposable
    {
        private readonly IRepositorioDeLeituraTickets _repositorioDeLeituraTickets;

        public ServicoDeCondutorTestes()
        {
            ExecuteQuery("INSERT INTO Ticket (DataHoraDeEntrada, Placa) VALUES ('2018-01-01 00:00:00.000', 'NHC 3030');");

            _repositorioDeLeituraTickets = new RepositorioDeLeituraDeTickets();
        }

        [Fact]
        public void Deve_obter_um_bilhete_emitido()
        {
            //arrange
            IServicoDeCondutor servicoDeCondutor = new ServicoDeCondutor(_repositorioDeLeituraTickets);

            //act
            var bilhete = servicoDeCondutor.ObterBilheteEmitidoPor(1);

            //assert
            var placaEsperada = new Placa("NHC 3030");
            var veiculoEsperado = new Veiculo(placaEsperada);
            var bilheteEsperado = new Bilhete(1, new DateTime(2018, 01, 01, 00, 00, 000), veiculoEsperado);
            Assert.Equal(bilheteEsperado, bilhete);
        }

        public void Dispose()
        {
            ExecuteQuery("TRUNCATE TABLE Ticket;");
        }

        private static void ExecuteQuery(string query)
        {
            using (ISession sessao = SessionNHibernate.Criar().OpenSession())
            {
                using (var transacao = sessao.BeginTransaction())
                {
                    sessao.CreateSQLQuery(query).ExecuteUpdate();
                    transacao.Commit();
                }
            }
        }
    }
}
