using System;
using Balanceless.DAO;

public class Program
{
    public static void Main(string[] args)
    {
        var sqlDao = SqlDao.GetInstance();

        Console.WriteLine("=== CINEFOCINEMAS ===");
        Console.WriteLine("1. Registrar nuevo usuario");
        Console.WriteLine("2. Agregar nueva película");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");

        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                RegistrarUsuario(sqlDao);
                break;
            case "2":
                AgregarPelicula(sqlDao);
                break;
            case "3":
                Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }
    }

    public static void RegistrarUsuario(SqlDao sqlDao)
    {
        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el codigo de usuario");
        var userCode = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre completo");
        var name = Console.ReadLine();

        Console.WriteLine("Ingrese el email");
        var email = Console.ReadLine();

        Console.WriteLine("Ingrese la contrasenia");
        var pwd = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha de nacimiento *MM-dd-yyyy*");
        var birthDate = DateTime.Parse(Console.ReadLine());

        var status = "AC";

        Console.WriteLine("Ingrese el telefono ");
        var phone = int.Parse(Console.ReadLine());
         
        sqlOperation.ProcedureName = "CRE_USER_PR";
        sqlOperation.AddStringParameter("P_USER_CODE", userCode);
        sqlOperation.AddStringParameter("P_NAME", name);
        sqlOperation.AddStringParameter("P_EMAIL", email);
        sqlOperation.AddStringParameter("P_PASSWORD", pwd);
        sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", birthDate);
        sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);
        sqlOperation.AddStringParameter("P_STATUS", status);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Usuario registrado exitosamente!");
    }

    public static void AgregarPelicula(SqlDao sqlDao)
    {
        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el título de la película");
        var title = Console.ReadLine();

        Console.WriteLine("Ingrese la sinopsis");
        var sinopsis = Console.ReadLine();

        Console.WriteLine("Ingrese el género");
        var genre = Console.ReadLine();

        Console.WriteLine("Ingrese la duración (en minutos)");
        var duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la clasificación (PG-13, R, PG, etc.)");
        var clasification = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre de la imagen");
        var image = Console.ReadLine();

        var status = "AC";

        sqlOperation.ProcedureName = "CRE_MOVIE_PR";
        sqlOperation.AddStringParameter("P_TITLE", title);
        sqlOperation.AddStringParameter("P_SINOPSIS", sinopsis);
        sqlOperation.AddStringParameter("P_GENRE", genre);
        sqlOperation.AddIntParameter("P_DURATION", duration);
        sqlOperation.AddStringParameter("P_CLASIFICATION", clasification);
        sqlOperation.AddStringParameter("P_IMAGE", image);
        sqlOperation.AddStringParameter("P_STATUS", status);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Película agregada exitosamente!");
    }
}