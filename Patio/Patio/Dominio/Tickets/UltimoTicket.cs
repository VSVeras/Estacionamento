using System;
using System.Linq.Expressions;

namespace Patio.Dominio.Tickets
{
    // Abstração para uso do pattern specification: https://en.wikipedia.org/wiki/Specification_pattern
    public sealed class UltimoTicket
    {
        public static Expression<Func<Ticket, bool>> Hoje => 
            OndeOCampo => OndeOCampo.DataHoraDeEntrada.Date >= DateTime.UtcNow.Date;
    }
}
