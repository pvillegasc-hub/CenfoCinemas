using DataAccess.CRUD;
using Entities_DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    //Logica del negocio
    public class UserManager
    {
        public List<User> RetrieveAllUsers()
        {   
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();
     
       }


        public void Create(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Create(u);
        }



    }
}