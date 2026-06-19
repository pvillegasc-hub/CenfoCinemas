using Balanceless.DAO;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            //Conviertiendo el baseDTO en un objeto Movie
            var movie = baseDTO as Movie;

            //Definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SINOPSIS", movie.Sinopsis);
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddStringParameter("P_CLASIFICATION", movie.Clasification);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}