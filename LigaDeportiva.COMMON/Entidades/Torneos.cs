﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Entidades
{
   public class Torneos:Base
    {
        public string FechaProgramada { get; set; }
        public string Tipo_Deporte { get; set; }
        public string Equipo1 { get; set; }
        public int Marcador_1 { get; set; }
        public string Equipo2 { get; set; }
        public int Marcador_2 { get; set; }
    }
}
