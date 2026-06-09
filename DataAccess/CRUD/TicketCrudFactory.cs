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
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}