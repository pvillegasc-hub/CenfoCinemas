using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    //Logica del negocio
    public class UserManager
    {
        //Reference
        public List<User> RetrieveAllUsers()
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAllUsers();
        }

        //Reference
        public void Create(User u)
        {
            var uCrud = new UserCrudFactory();

            //Validamos que el usuario sea mayor de 18 anos
            if (IsOver18(u))
            {
                uCrud.Create(u);
            }
            else
            {
                throw new Exception("Usuario no cumple con la edad mínima para el registro");
            }
        }

        //Reference
        public void Update(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Update(u);
        }

        //Reference
        public void Delete(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Delete(u);
        }

        //Reference
        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;

            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddDays(-age).Date)
            {
                age--;
            }

            return age >= 18;
        }
    }
}