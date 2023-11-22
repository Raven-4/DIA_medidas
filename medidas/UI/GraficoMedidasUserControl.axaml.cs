using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using medidas.Core;

namespace medidas.UI;

public partial class GraficoMedidasUserControl : UserControl
{
    public GraficoMedidasUserControl()
    {
        InitializeComponent();

        //Buscar como hacer grafico

        CrearGrafico();
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void CrearGrafico()
    {
        List<Medidas> medidas = XmlMedidas.XmlToMedidas();

        foreach (var medida in medidas)
        {
            Console.WriteLine($"Peso: {medida.Peso}, Circunferencia: {medida.CircunferenciaAbdominal}, Notas: {medida.Notas}");
        }
        //Meter medidas en grafico
    }

}
