using Balanceless.DAO;  // ← Cambia DataAccess.DAO por Balanceless.DAO
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
            sqlDao = SqlDao.GetInstance();  // Ya no necesitas DataAccess.DAO.
        }

        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();  // Ya no necesitas DataAccess.DAO.
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
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}