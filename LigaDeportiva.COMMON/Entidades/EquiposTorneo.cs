using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Entidades
{
    public class EquiposTorneo:Base
    {
        public string Nombre { get; set; }
        public string Director { get; set; }
        // public List<Integrantes> IntegrantesEquipo { get; set; }
        public string Tipo_De_Deporte { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
