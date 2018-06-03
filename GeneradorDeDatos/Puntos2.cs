using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeDatos
{
   public  class Puntos2
    {
        public double X { get; set; }
        //  public string NombreDeporte { get; set; }
        public double Y { get; set; }
        public Puntos2(double x, double y)
        {
            X = x;
            Y = y;
            //    NombreDeporte = deporte;
        }
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
