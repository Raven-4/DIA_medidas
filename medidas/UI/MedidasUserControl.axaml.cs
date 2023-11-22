using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using medidas.Core;

namespace medidas.UI;

public partial class MedidasUserControl : UserControl
{
    public MedidasUserControl()
    {
        InitializeComponent();

        var fechaDatePicker = this.FindControl<DatePicker>("FechaDatePicker");

        var pesoTextBox = this.FindControl<TextBox>("PesoTextBox");
        var circunferenciaTextBox = this.FindControl<TextBox>("CircunferenciaTextBox");
        var notasTextBox = this.FindControl<TextBox>("NotasTextBox");

        var guardarButton = this.FindControl<Button>("GuardarButton");

        guardarButton.Click += (_, _) => this.GuardarMedidas();
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void GuardarMedidas()
    {
        double peso = Convert.ToDouble(this.FindControl<TextBox>("PesoTextBox").Text);
        double circunferencia = Convert.ToDouble(this.FindControl<TextBox>("CircunferenciaTextBox").Text);
        string notas = Convert.ToString(this.FindControl<TextBox>("NotasTextBox").Text);
        DateTime fecha = this.FindControl<DatePicker>("FechaDatePicker").SelectedDate.Value.DateTime;

        XmlMedidas.MedidasToXml(peso, circunferencia, notas, fecha);
    }
}
