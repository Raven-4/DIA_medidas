using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using medidas.Core;

namespace medidas.UI;

public partial class MedidasUserControl : UserControl
{
    public MedidasUserControl()
    {
        InitializeComponent();

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
        try{
            double peso = Convert.ToDouble(pesoTextBox.Text);
            double circunferencia = Convert.ToDouble(circunferenciaTextBox.Text);
            string notas = Convert.ToDouble(notasTextBox.Text);

            Medidas nuevaMedida = new Medidas(peso, circunferencia, notas);

            //List<Medidas> listaMedidas = SacarMedidas();

            listaMedidas.Add(nuevaMedida);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Medidas>));

            using (TextWriter writer = new StreamWriter("medidas.xml")){
                serializer.Serialize(writer, listaMedidas);
            }

            //Console.WriteLine("Medidas guardadas correctamente en el archivo medidas.xml.");
        }catch (Exception ex){
            //Console.WriteLine($"Error al guardar las medidas: {ex.Message}");
        }
    }
}
