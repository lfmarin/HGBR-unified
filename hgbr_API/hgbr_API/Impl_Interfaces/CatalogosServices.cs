﻿//  El problema posiblemente provenga de la inyeccion de depedencias para que jale el context, debo checar eso con 
//  Varela
using System.Linq;
using hgbr_API.Interfaces;
using hgbr_API.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class CatalogosServices : ICatalogosServices
    {
        private readonly HgbrContext context;
        public CatalogosServices(HgbrContext context)
        {
            this.context = context;
        }

        //  Se esta intentando consumir la informacion de la BD con la implementacion de estos metodos
        public IQueryable<object> getAllEstadoConyugal()
        {
            try
            {
                return context.EstadoConyugals.Select(item => new
                {
                    idEstadoConyugal = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IQueryable<object> getAllTipoAsentamiento()
        {
            try
            {
                return context.TipoAsentamientos.Select(item => new
                {
                    idTipoAsentamiento = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IQueryable<object> getAllTipoVialidad()
        {
            try
            {
                return context.TipoVialidads.Select(item => new {
                    idTipoVialidad = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IQueryable<object> getAllSexo()
        {
            try
            {
                return context.Sexos.Select(item => new {
                    idSexo = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}