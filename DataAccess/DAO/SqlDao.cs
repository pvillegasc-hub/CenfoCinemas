using Balanceless.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class SqlDao
{
    private static SqlDao instance;
    private string connectionString;

    private SqlDao()
    {
        connectionString = @"Data Source=DESKTOP-IEFR6P5;Initial Catalog=cenfocinemas-db;Integrated Security=True;TrustServerCertificate=True";
    }

    public static SqlDao GetInstance()
    {
        if (instance == null)
        {
            instance = new SqlDao();
        }
        return instance;
    }

    public void ExecuteProcedure(SqlOperation sqlOperation)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    // Metodo para ejecutar SP en la base de datos y obtener un resultado de respuesta
    public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
    {
        var lstResults = new List<Dictionary<string, object>>();

        using (var conn = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Set de los parametros que utiliza el SP
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                // Ejecuta el SP
                conn.Open();
                
                // Ejecucion del SP con retorno de datos usando SqlDataReader
                using (var reader = command.ExecuteReader())
                {
                    // Lectura de data set
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();

                            for (var index = 0; index < reader.FieldCount; index++)
                            {
                                var key = reader.GetName(index);
                                var value = reader.GetValue(index);

                                row[key] = value;
                            }

                            lstResults.Add(row);
                        }
                    }
                }
            }
        }

        return lstResults;
    }
}