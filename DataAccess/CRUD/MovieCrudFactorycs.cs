using Balanceless.DAO;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD
{
    public class CrudMovieFactory : CrudFactory
    {
        public CrudMovieFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SINOPSIS", movie.Sinopsis);
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddStringParameter("P_CLASIFICATION", movie.Clasification);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_MOVIE_PR";

            sqlOperation.AddIntParameter("P_ID", movie.Id);
            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SINOPSIS", movie.Sinopsis);
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddStringParameter("P_CLASIFICATION", movie.Clasification);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_MOVIE_PR";
            sqlOperation.AddIntParameter("P_ID", movie.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_MOVIE_BY_ID_PR";
            sqlOperation.AddIntParameter("P_ID", id);

            var results = sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (results.Count > 0)
            {
                var row = results[0];
                var movie = new Movie
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Sinopsis = (string)row["Sinopsis"],
                    Genre = (string)row["Genre"],
                    Duration = (int)row["Duration"],
                    Clasification = (string)row["Clasification"],
                    Image = (string)row["Image"],
                    Status = (string)row["Status"]
                };
                return (T)(object)movie;
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_ALL_MOVIES_PR";

            var results = sqlDao.ExecuteQueryProcedure(sqlOperation);

            var movies = new List<T>();
            foreach (var row in results)
            {
                var movie = new Movie
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Sinopsis = (string)row["Sinopsis"],
                    Genre = (string)row["Genre"],
                    Duration = (int)row["Duration"],
                    Clasification = (string)row["Clasification"],
                    Image = (string)row["Image"],
                    Status = (string)row["Status"]
                };
                movies.Add((T)(object)movie);
            }
            return movies;
        }
    }
}