using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace medidas.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void InitializeComponent()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        AvaloniaXamlLoader.Load(this);
    }
}