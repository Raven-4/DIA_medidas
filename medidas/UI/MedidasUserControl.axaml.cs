using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
        double peso = Convert.ToDouble(pesoTextBox.Text);
        double circunferencia = Convert.ToDouble(circunferenciaTextBox.Text);
        string notas = Convert.ToDouble(notasTextBox.Text);

        XmlMedidas.MedidasToXml(peso, circunferencia, notas);
    }
}
