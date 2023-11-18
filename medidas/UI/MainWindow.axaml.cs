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
    //private List<Medidas> medidasMensuales = new List<Medidas>();
    private ContentControl contentControl;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        contentControl = this.FindControl<ContentControl>("ContentControl");

        var opMedidasButton = this.FindControl<Button>("AbrirMedidas");

        opMedidasButton.Click += (_, _) => this.OnViewMedidas();

    }

    void InitializeComponent()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        AvaloniaXamlLoader.Load(this);
    }

    public void OnViewMedidas()
    {
        var medidasUserControl = new MedidasUserControl();
        contentControl.Content = medidasUserControl;
    }
}