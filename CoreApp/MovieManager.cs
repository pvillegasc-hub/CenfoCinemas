using DataAccess.CRUD;
using Entities_DTOs;
using Entities_DTOs.Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    // Logica de Negocio
    public class MovieManager
    {
        public List<Movie> RetrieveAllMovies()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movie>();
        }

        public void Create(Movie m)
        {
            var mCrud = new MovieCrudFactory();

            // Validaciones de forma

            if (HasEmptyFields(m))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidStatus(m))
                throw new Exception("Estado inválido. Valores permitidos: Ac o In");

            // Validaciones de negocio

            if (!HasMinimumDuration(m))
                throw new Exception("La película debe tener una duración mínima de 60 minutos");

            mCrud.Create(m);
        }

        public void Update(Movie m)
        {
            var mCrud = new MovieCrudFactory();

            // Validaciones de forma

            if (HasEmptyFields(m))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidStatus(m))
                throw new Exception("Estado inválido. Valores permitidos: Ac o In");

            // Validaciones de negocio

            if (!HasMinimumDuration(m))
                throw new Exception("La película debe tener una duración mínima de 120 minutos");

            mCrud.Update(m);
        }

        public void Delete(Movie m)
        {
            var mCrud = new MovieCrudFactory();
            mCrud.Delete(m);
        }


        // Validaciones de forma

        // Validar campos requeridos
        private bool HasEmptyFields(Movie movie)
        {
            return string.IsNullOrWhiteSpace(movie.Title) ||
                   string.IsNullOrWhiteSpace(movie.Sinopsis) ||
                   string.IsNullOrWhiteSpace(movie.Genre) ||
                   string.IsNullOrWhiteSpace(movie.Clasification) ||
                   string.IsNullOrWhiteSpace(movie.Image) ||
                   string.IsNullOrWhiteSpace(movie.Status);
        }

        // Validar que el estado sea correcto
        private bool IsValidStatus(Movie movie)
        {
            return movie.Status.ToUpper() == "AC" || movie.Status.ToUpper() == "IN";
        }

        // Validacion de negocio

        // Validar duración mínima
        private bool HasMinimumDuration(Movie movie)
        {
            return movie.Duration >= 120;
        }
    }
}