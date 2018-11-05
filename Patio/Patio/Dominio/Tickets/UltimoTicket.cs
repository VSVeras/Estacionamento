using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Patio.Dominio.Tickets
{
    internal class UltimoTicket
    {
        public static Expression<Func<Ticket, bool>> Hoje => 
            OndeOCampo => OndeOCampo.DataHoraDeEntrada.Date == DateTime.UtcNow.Date;
    }
}
