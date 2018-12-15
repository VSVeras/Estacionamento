using FluentNHibernate.Mapping;
using Patio.Dominio.Tickets;

namespace Patio.Infraestrutura.Mapeamentos
{
    internal sealed class MapeamentoDeTicket : ClassMap<Ticket>
    {
        public MapeamentoDeTicket()
        {
            Schema("dbo");
            Table("Ticket");

            Id(atributo => atributo.Id).GeneratedBy.Identity();

            Component(objetoDeValor => objetoDeValor.Veiculo, entidade =>
            {
                entidade.Map(atributo => atributo.Placa).Column("Placa").Not.Nullable(); ;
            });

            Map(atributo => atributo.DataHoraDeEntrada).Not.Nullable(); ;
        }
    }
}
