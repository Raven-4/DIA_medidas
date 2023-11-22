using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;

using medidas.Core;
using LiveChartsCore.SkiaSharpView.Avalonia;

namespace medidas.UI;

public partial class GraficoMedidasUserControl : UserControl
{
    public GraficoMedidasUserControl()
    {
        InitializeComponent();

        CrearGrafico();
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void CrearGrafico()
    {
        List<Medidas> medidas = XmlMedidas.XmlToMedidas();

        /*foreach (var medida in medidas)
        {
            Console.WriteLine($"Peso: {medida.Peso}, Circunferencia: {medida.CircunferenciaAbdominal}, Notas: {medida.Notas}");
        }*/

        //ConfigurarGrafico(chart, "Circunferencia abdominal y Pesos");

    }

}
