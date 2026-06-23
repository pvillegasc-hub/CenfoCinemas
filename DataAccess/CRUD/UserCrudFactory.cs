using Balanceless.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            //Convirtiendo el baseDTO en un objeto usuario
            var user = baseDTO as User;

            //definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParameter("P_USER_CODE", user.UserCode);
            sqlOperation.AddStringParameter("P_NAME", user.Name);
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            sqlOperation.AddStringParameter("P_PASSWORD", user.Password);
            sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddIntParameter("P_PHONE_NUMBER", user.PhoneNumber);
            sqlOperation.AddStringParameter("P_STATUS", user.Status);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            //Convirtiendo el baseDTO en un objeto usuario
            var user = baseDTO as User;

            //definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_USER_PR";

            sqlOperation.AddIntParameter("P_ID", user.Id);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_USER_PR";

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                foreach (var result in lstResults)
                {
                    var user = BuildUser(result);

                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }

            return lstUsers;
        }

        public List<User> RetrieveAllUsers()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_USER_BY_ID_PR";
            operation.AddIntParameter("P_ID", id);

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                var item = lstResults[0];

                var user = BuildUser(item);

                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            //Convirtiendo el baseDTO en un objeto usuario
            var user = baseDTO as User;

            //definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            sqlOperation.AddIntParameter("P_ID", user.Id);
            sqlOperation.AddStringParameter("P_USER_CODE", user.UserCode);
            sqlOperation.AddStringParameter("P_NAME", user.Name);
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            sqlOperation.AddStringParameter("P_PASSWORD", user.Password);
            sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddIntParameter("P_PHONE_NUMBER", user.PhoneNumber);
            sqlOperation.AddStringParameter("P_STATUS", user.Status);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        //Metodo que construye el DTO del usuario a partir de la data que viene en la consulta de la BD
        private User BuildUser(Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                UserCode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                Status = (string)row["Status"],
                BirthDate = (DateTime)row["BirthDate"],
            };

            return user;
        }
    }
}