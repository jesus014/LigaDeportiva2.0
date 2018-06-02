using LigaDeportiva.COMMON.Entidades;
using LigaDeportiva.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaDeportiva.BIZ
{
    public class ManejadorDeporte : IManejadorDeporte
    {
        IRepositorio <Deporte> deporte;
        public ManejadorDeporte(IRepositorio<Deporte>deporte)
        {
            this.deporte = deporte;

        }

        public List<Deporte> Lista => deporte.Lista.OrderBy(p => p.Tipo_Deporte).ToList();

        public bool Agregar(Deporte entidad)
        {
            return deporte.Crear(entidad);
        }

        public Deporte Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Tipo_Deporte == Id.ToString()).SingleOrDefault();
        }

        public bool Eliminar(ObjectId Id)
        {
            return deporte.Eliminar(Id);
        }

            public bool Modificar(Deporte entidad)
        {
            return deporte.Editar(entidad);
        }
    }
}
