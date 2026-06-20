using Balanceless.DAO;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;

namespace DataAccess.CRUD
{
    public class TicketCrudFactory : CrudFactory
    {
        public TicketCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_TICKET_PR";

            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddStringParameter("P_PRICE", ticket.Price.ToString());
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_TICKET_PR";

            sqlOperation.AddIntParameter("P_ID", ticket.Id);
            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddStringParameter("P_PRICE", ticket.Price.ToString());
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_TICKET_PR";
            sqlOperation.AddIntParameter("P_ID", ticket.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T RetrieveById<T>(int id)
        {
            // Definir el SP
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_TICKET_BY_ID_PR";

            operation.AddIntParameter("P_ID", id);

            // Ejecutar el SP
            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

            // Recorrer la lista de resultados y convertir el resultado en un objeto Ticket, para luego retornarlo
            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var ticket = BuildTicket(row);

                return (T)Convert.ChangeType(ticket, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            // Lista que va a contener a todos los tickets que se obtengan de la consulta a la BD
            var lstTickets = new List<T>();

            // Definir el SP
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_TICKETS_PR";

            // Ejecutar el SP
            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

            // Recorrer la lista de resultados y convertir cada resultado en un objeto Ticket, para luego agregarlo a la lista de tickets
            if (lstResult.Count > 0)
            {
                foreach (var result in lstResult)
                {
                    var ticket = BuildTicket(result);

                    lstTickets.Add((T)Convert.ChangeType(ticket, typeof(T)));
                }
            }
            return lstTickets;
        }
        private Ticket BuildTicket(Dictionary<string, object> row)
        {
            // // Crea un nuevo objeto Ticket y asigna sus propiedades a partir de los valores del diccionario
            var ticket = new Ticket()
            {
                Id = (int)row["Id"],
                //Created = (DateTime)row["Created"],
                Price = (decimal)row["Price"],
                Schedule = (string)row["Schedule"],
                Date = (DateTime)row["Date"],
                Type = (string)row["Type"]
            
            };

            return ticket;
        }



    }
}