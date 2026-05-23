using Balanceless.DAO;
using System.Data.SqlClient;

    public class SqlDao
{
    private static SqlDao instance;
    private string connectionString;

    private SqlDao()
    {
        connectionString = string.Empty;
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
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}