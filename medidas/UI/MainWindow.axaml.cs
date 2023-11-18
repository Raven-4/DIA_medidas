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
    private ContentControl contentControl;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        contentControl = this.FindControl<ContentControl>("ContentControl");

        var opMedidasButtonGuardar = this.FindControl<Button>("AbrirGuardarMedidas");
        var opMedidasButtonGrafico = this.FindControl<Button>("AbrirGraficoMedidas");

        opMedidasButtonGuardar.Click += (_, _) => this.OnViewMedidasGuardar();
        opMedidasButtonGrafico.Click += (_, _) => this.OnViewGraphicMedidas();

    }

    void InitializeComponent()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        AvaloniaXamlLoader.Load(this);
    }

    public void OnViewMedidasGuardar()
    {
        var medidasUserControl = new MedidasUserControl();
        contentControl.Content = medidasUserControl;
    }

    public void OnViewGraphicMedidas()
    {
        var graficoMedidas = new GraficoMedidasUserControl();
        contentControl.Content = graficoMedidas;
    }
}