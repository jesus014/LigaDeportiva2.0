﻿using LigaDeportiva.COMMON.Entidades;
using LigaDeportiva.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaDeportiva.BIZ
{
    public class ManejadorTorneo : IManejadorTorneo
    {
        IRepositorio<Torneos> torneo;

        public ManejadorTorneo(IRepositorio<Torneos>torneo)
        {
            this.torneo = torneo;
        }

        public List<Torneos> Lista => torneo.Lista.OrderBy(p => p.FechaProgramada).OrderBy(e => e.Tipo_Deporte).ToList();

        public bool Agregar(Torneos entidad)
        {
            return torneo.Crear(entidad);
        }

        public Torneos Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId Id)
        {
            return torneo.Eliminar(Id);
        }

        public bool Modificar(Torneos entidad)
        {
            return torneo.Editar(entidad);
        }

        public int VerificarSiEsNumero(string text)
        {
            foreach (var item in text)
            {
                if (!(char.IsNumber(item)))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 1;
        
    }
    }
}
