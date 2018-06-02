using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Entidades
{
    public class Administrador:Base
    {
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string NombreDeUsuario { get; set; }
        public override string ToString()
        {
            return NombreDeUsuario;
        }
    }
}
