using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

using medidas.Core;

using System.Collections.Generic;
using System.Linq;

namespace medidas.UI;

public partial class MainWindow : Window
{
    private List<Medidas> medidasMensuales = new List<Medidas>();
    //private TextBlock texto;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    void InitializeComponent()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        AvaloniaXamlLoader.Load(this);
    }

    /*private void Boton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Pedir al usuario que ingrese las medidas
        var peso = Convert.ToDouble(ShowInputDialog("Peso (kg):"));
        var circunferenciaAbdominal = Convert.ToDouble(ShowInputDialog("Circunferencia abdominal (cm):"));
        var notas = ShowInputDialog("Notas:");

        // Crear un objeto Medidas y agregarlo a la lista
        Medidas medidas = new Medidas(peso, circunferenciaAbdominal, notas);
        medidasMensuales.Add(medidas);

        // Mostrar las medidas registradas
        MostrarMedidas();
    }

    private void MostrarMedidas()
    {
        texto.Text = "Evolución Mensual:\n";
        texto.Text += "Mes\tPeso\tCircunferencia Abdominal\tNotas\n";

        for (int i = 0; i < medidasMensuales.Count; i++)
        {
            Medidas medidas = medidasMensuales[i];
            texto.Text += $"{i + 1}\t{medidas.Peso}\t{medidas.CircunferenciaAbdominal}\t\t\t{medidas.Notas}\n";
        }
    }*/
}