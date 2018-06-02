using LigaDeportiva.COMMON.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.Interfaces
{
    public interface IManejadorEquipo: IManejadorGenerico<EquiposTorneo>
    {
        bool ContarNumeroTelefonico(string telefono);
        bool VerificarSiEsNumero(string telefono);
        IEnumerable BuscarEquipos(string palabra);
        int ContadorDeBuscarEquipo(string palabra);

        int Aleatorios(string palabra);
    }
}
