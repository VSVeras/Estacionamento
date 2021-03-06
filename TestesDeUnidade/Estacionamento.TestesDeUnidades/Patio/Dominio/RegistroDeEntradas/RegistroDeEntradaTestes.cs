﻿using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Infraestrutura.SistemaOperacional;
using Patio.Dominio.Condutores;
using Patio.Dominio.RegistroDeEntradas;
using Xunit;

namespace Estacionamento.TestesDeUnidades.Patio.Dominio.RegistroDeEntradas
{
    public class RegistroDeEntradaTestes
    {
        [Fact]
        public void Deve_registrar_a_entrada_de_um_veiculo()
        {
            //arrange
            var placaPadrao = "NHC 3030";
            IServicoDeEstacionamento servicoDeEstacionamento = new Condutor();
            IProvedorDoTempo provedorDoTempo = new ProvedorDataHoraSistema();

            //act
            var ticket = RegistroDeEntrada.Criar(provedorDoTempo, servicoDeEstacionamento, placaPadrao);

            //assert
            var veiculoEsperado = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            Assert.NotNull(ticket);
            Assert.Equal(veiculoEsperado, ticket.Veiculo);
        }
    }
}
