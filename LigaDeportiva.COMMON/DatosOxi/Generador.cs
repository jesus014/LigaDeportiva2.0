using LigaDeportiva.COMMON.ListaInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LigaDeportiva.COMMON.DatosOxi
{
  public  class Generador
    {

        public Generador()
        {
            Puntos = new List<Puntos>();
        }

        public List<Puntos> Puntos { get; set; }

        public List<Puntos> GeneradorDatos(List<TorneoLista> listatorneo, double limiteInferior, double limiteSuperior, double incremento)
        {
            Puntos = new List<Puntos>();
            double contador = 1;
            foreach (var item in listatorneo)
            {
                Puntos.Add(new Puntos(contador++, item.Puntaje));
            }
            return Puntos;
        }
    }
}
