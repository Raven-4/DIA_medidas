namespace medidas.Core;

class Medidas
{
    public double Peso { get; set; }
    public double CircunferenciaAbdominal { get; set; }
    public string Notas { get; set; }

    public Medidas(double peso, double circunferenciaAbdominal, string notas)
    {
        Peso = peso;
        CircunferenciaAbdominal = circunferenciaAbdominal;
        Notas = notas;
    }
}
