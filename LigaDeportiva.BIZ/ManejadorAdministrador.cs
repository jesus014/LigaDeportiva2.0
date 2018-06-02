using LigaDeportiva.COMMON.Entidades;
using LigaDeportiva.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaDeportiva.BIZ
{
    public class ManejadorAdministrador : IManejadorAdministrador

    {
        IRepositorio<Administrador> admi;
        public ManejadorAdministrador(IRepositorio<Administrador> adminis)
        {
            this.admi = adminis;
        }

        public List<Administrador> Lista => admi.Lista.OrderBy(p => p.Nombre).OrderBy(e => e.NombreDeUsuario).ToList();

        public bool Agregar(Administrador entidad)
        {
            return admi.Crear(entidad);
        }

        public Administrador Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

            public bool Eliminar(ObjectId Id)
        {
            return admi.Eliminar(Id);
        }

        public bool Modificar(Administrador entidad)
        {
            return admi.Editar(entidad);
        }
    }
}
