using DataAccess.CRUD;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;
using System.Collections.Generic;

namespace CoreApp
{
    public class TicketManager
    {
        //Reference
        public List<Ticket> RetrieveAllTickets()
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveAll<Ticket>();
        }

        //Reference
        public void Create(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }

        //Reference
        public void Update(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Update(t);
        }

        //Reference
        public void Delete(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Delete(t);
        }
    }
}