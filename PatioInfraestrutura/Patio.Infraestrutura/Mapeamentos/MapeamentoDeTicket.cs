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

            // Mapeamento para o objeto de valor
            Component(atributoVeiculo => atributoVeiculo.Veiculo, propriedadeDoVeiculo =>
            {
                propriedadeDoVeiculo.Component(atributoPlaca => atributoPlaca.Placa, propriedadeDaPlaca =>
                {
                    propriedadeDaPlaca.Map(Campo => Campo.Valor).Column("Placa").Not.Nullable().Length(9);
                });
            });

            Map(atributo => atributo.DataHoraDeEntrada).Not.Nullable();
        }
    }
}
