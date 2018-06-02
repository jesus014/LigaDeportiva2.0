using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Entidades
{
   public class Deporte:Base
    {
        public string Tipo_Deporte { get; set; }
        public string LugarDeporte { get; set; }

        public override string ToString()
        {
            return Tipo_Deporte;
        }
    }
}
