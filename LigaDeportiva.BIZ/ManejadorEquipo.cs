using LigaDeportiva.COMMON.Entidades;
using LigaDeportiva.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaDeportiva.BIZ
{
    public class ManejadorEquipo : IManejadorEquipo
    {
        IRepositorio<EquiposTorneo> equipo;
        public ManejadorEquipo(IRepositorio<EquiposTorneo>usuario)
        {
            this.equipo = usuario;

        }

        public List<EquiposTorneo> Lista => equipo.Lista.OrderBy(p => p.Nombre).OrderBy(e => e.Tipo_De_Deporte).ToList();

        public bool Agregar(EquiposTorneo entidad)
        {
            return equipo.Crear(entidad);
        }

        public int Aleatorios(string palabra)
        {
            int valor = ContadorDeBuscarEquipo(palabra);
            Random a = new Random();
            int v = 0;
            return v = a.Next(1, valor);
        }

        public EquiposTorneo Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Tipo_De_Deporte == Id.ToString()).SingleOrDefault();
        }

        public IEnumerable BuscarEquipos(string palabra)
        {
            return Lista.Where(e => e.Tipo_De_Deporte == palabra).ToList();
        }

        public int ContadorDeBuscarEquipo(string palabra)
        {
            return Lista.Where(e => e.Tipo_De_Deporte == palabra).ToList().Count();
        }

        public bool ContarNumeroTelefonico(string telefono)
        {
            int var = 0;
            for (int i = 0; i <= telefono.Count(); i++)
            {

                if (i != 32)
                {

                    var++;
                }
            }
            if (var == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(ObjectId Id)
        {
            return equipo.Eliminar(Id);
        }

        public bool Modificar(EquiposTorneo entidad)
        {
            return equipo.Editar(entidad);
        }

        public bool VerificarSiEsNumero(string telefono)
        {
            foreach (var item in telefono)
            {
                if (!(char.IsNumber(item)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
    }

