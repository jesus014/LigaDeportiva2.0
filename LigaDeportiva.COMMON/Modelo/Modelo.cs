using LigaDeportiva.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Modelo
{
   public class Modelo
    {
        public string NumeroTorneo { get; set; }
        public string FechaTorneo { get; set; }
        public string Equipo { get; set; }
        public string Equipo2 { get; set; }
        public Modelo(Torneos torneos)
        {
            Equipo = string.Format("{0} {1} ", torneos.Equipo1, torneos.Marcador_1);
            Equipo2 = string.Format("{0} {1}", torneos.Equipo2, torneos.Marcador_2);
            FechaTorneo = torneos.FechaProgramada;
        }
    }
}
