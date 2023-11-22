using System;

namespace medidas.Core;

public class Medidas
{
    public double Peso { get; set; }
    public double CircunferenciaAbdominal { get; set; }
    public string Notas { get; set; }
    public DateTime Fecha { get; set; }


    public Medidas(double peso, double circunferenciaAbdominal, string notas, DateTime fecha)

    {
        Peso = peso;
        CircunferenciaAbdominal = circunferenciaAbdominal;
        Notas = notas;
        Fecha = fecha;
    }

    public Medidas()
    {

    }
}

