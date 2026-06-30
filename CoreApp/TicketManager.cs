using DataAccess.CRUD;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;
using System;
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


            // Validaciones

            if (t == null)
                throw new Exception("El ticket no puede ser nulo");


            if (HasEmptyFields(t))
                throw new Exception("Todos los campos son obligatorios");


            if (!IsValidPrice(t))
                throw new Exception("El precio debe ser mayor a 0");


            if (!IsValidType(t))
                throw new Exception("Tipo inválido. Valores permitidos: Adulto o Niños");


            tCrud.Create(t);
        }



        //Reference
        public void Update(Ticket t)
        {
            var tCrud = new TicketCrudFactory();


            // Validaciones

            if (t == null)
                throw new Exception("El ticket no puede ser nulo");


            if (HasEmptyFields(t))
                throw new Exception("Todos los campos son obligatorios");


            if (!IsValidPrice(t))
                throw new Exception("El precio debe ser mayor a 0");


            if (!IsValidType(t))
                throw new Exception("Tipo inválido. Valores permitidos: Adulto o Niños");


            tCrud.Update(t);
        }



        //Reference
        public void Delete(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Delete(t);
        }



        // Validaciones


        // Validar campos obligatorios

        private bool HasEmptyFields(Ticket t)
        {
            return string.IsNullOrWhiteSpace(t.Schedule) ||
                   string.IsNullOrWhiteSpace(t.Type) ||
                   t.Date == default(DateTime);
        }



        // Validar precio mayor a 0

        private bool IsValidPrice(Ticket t)
        {
            return t.Price > 0;
        }



        // Validar tipo de ticket

        private bool IsValidType(Ticket t)
        {
            return t.Type == "Adulto" ||
                   t.Type == "Niños";
        }

    }
}