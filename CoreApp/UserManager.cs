using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            return uCrud.RetrieveAll<User>();
        }

        //Referencia
        public void Create(User u)
        {
            var uCrud = new UserCrudFactory();

            // Validaciones completas antes de crear
            ValidateUser(u, true); // true = es creación (no verifica existencia de ID)

            //Validamos que el usuario sea mayor de 18 años
            if (IsOver18(u))
            {
                uCrud.Create(u);
            }
            else
            {
                throw new Exception("Usuario no cumple con la edad mínima para el registro");
            }
        }


        public void Update(User u)
        {
            var uCrud = new UserCrudFactory();

            // Validaciones completas antes de actualizar
            ValidateUser(u, false); // false = es actualización (verifica existencia de ID)

            uCrud.Update(u);
        }


        public void Delete(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Delete(u);
        }

        // Método centralizado de las validaciones
        private void ValidateUser(User user, bool isCreation)
        {
            // Verificar estado
            if (!IsValidStatus(user))
            {
                throw new Exception("El estado debe ser 'Ac' o 'In'");
            }

            // Verificar fecha de nacimiento
            if (!IsValidBirthDate(user))
            {
                throw new Exception("La fecha de nacimiento no puede ser futura");
            }

            if (EmailExists(user))
            {
                throw new Exception("El correo electrónico ya está registrado");
            }


            if (UserCodeExists(user))
            {
                throw new Exception("El código de usuario ya existe");
            }
        }


        private bool IsValidStatus(User user)
        {
            return user.Status.ToUpper() == "AC" || user.Status.ToUpper() == "IN";
        }

        // Verificar que la fecha de nacimiento no sea en el futuro
        private bool IsValidBirthDate(User user)
        {
            return user.BirthDate <= DateTime.Now;
        }

        // Verificar que el correo electrónico no este registrado ya en el sistema
        private bool EmailExists(User user)
        {
            var uCrud = new UserCrudFactory();
            var users = uCrud.RetrieveAll<User>();

            // Busca si existe otro usuario con el mismo correo pero diferente Id
            return users.Any(u => u.Email == user.Email && u.Id != user.Id);
        }

        // Verificar que el código de usuario no exista ya en el sistema
        private bool UserCodeExists(User user)
        {
            var uCrud = new UserCrudFactory();
            var users = uCrud.RetrieveAll<User>();

            // Busca si existe otro usuario con el mismo código pero diferente Id en el sistema
            return users.Any(u => u.UserCode == user.UserCode && u.Id != user.Id);
        }

        //Referencia
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