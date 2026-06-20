using DataAccess.CRUD;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    // Logica de Negocio
    public class TicketManager
    {
        public List<Ticket> RetrieveAllTickets()
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveAll<Ticket>();
        }

        public void Create(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }
    }
}