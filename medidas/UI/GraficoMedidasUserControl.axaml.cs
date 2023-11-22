using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
       //Meter medidas en grafico
    }

}
