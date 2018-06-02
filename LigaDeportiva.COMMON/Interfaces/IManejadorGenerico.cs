using LigaDeportiva.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Interfaces
{
   public interface IManejadorGenerico<T> where T:Base

    {
        bool Agregar(T entidad);
        List<T> Lista { get; }
        bool Eliminar(ObjectId Id);
        bool Modificar(T entidad);
        T Buscador(ObjectId Id);

    }
}
