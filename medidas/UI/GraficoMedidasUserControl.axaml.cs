using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

using medidas.Core;
using LiveChartsCore.SkiaSharpView.Avalonia;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Globalization;
using Avalonia.Media;
using Avalonia.Controls.Shapes;

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
        // Ordenar las medidas por fecha
        medidas = medidas.OrderBy(m => m.Fecha).ToList();


        foreach (var medida in medidas)
        {
            Console.WriteLine($"Peso: {medida.Peso}, Circunferencia: {medida.CircunferenciaAbdominal}, Notas: {medida.Notas}");
        }

        if (medidas.Count > 0)
        {
            var chartCircunferencia = this.FindControl<Canvas>("chartCircunferencia");
            var chartPeso = this.FindControl<Canvas>("chartPeso");
            var dates = medidas.Select(m => m.Fecha.ToString("yyyy-MM-dd"));

            // Escalar las medidas para que se ajusten al tamaño del canvas
            var scaledCircunferencia = EscalarValores(medidas.Select(m => m.CircunferenciaAbdominal), chartCircunferencia.Height);
            var scaledPeso = EscalarValores(medidas.Select(m => m.Peso), chartPeso.Height);

            // Dibujar líneas en el chartCircunferencia
            DibujarEjes(chartCircunferencia, dates, chartCircunferencia.Width, chartCircunferencia.Height);
            DibujarLineas(chartCircunferencia, dates, scaledCircunferencia, Colors.Blue);

            // Dibujar líneas en el chartPeso
            DibujarEjes(chartPeso, dates, chartPeso.Width, chartPeso.Height);
            DibujarLineas(chartPeso, dates, scaledPeso, Colors.Red);

            // Serie para Circunferencia Abdominal
            /*var seriesCircunferencia = new LineSeries<double>
            {
                Values = medidas.Select(m => m.CircunferenciaAbdominal),
                Stroke = new SolidColorPaint(SKColors.Blue),
                Fill = null,
                LineSmoothness = 0
            };

            // Serie para Peso
            var seriesPeso = new LineSeries<double>
            {
                Values = medidas.Select(m => m.Peso),
                Stroke = new SolidColorPaint(SKColors.Red),
                Fill = null,
                LineSmoothness = 0
            };

            chartCircunferencia.Series = new ISeries[]{
            seriesCircunferencia
            };

            chartPeso.Series = new ISeries[]{
            seriesPeso
            };*/

        }
    }
    private void DibujarEjes(Canvas canvas, IEnumerable<string> dates, double width, double height)
    {
        var xAxis = new Path
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        var xGeometry = new PathGeometry();
        var xFigure = new PathFigure
        {
            StartPoint = new Point(0, canvas.Height),
            IsClosed = false
        };

        xFigure.Segments.Add(new LineSegment { Point = new Point(canvas.Width, canvas.Height) });
        xGeometry.Figures.Add(xFigure);
        xAxis.Data = xGeometry;

        var yAxis = new Path
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        var yGeometry = new PathGeometry();
        var yFigure = new PathFigure
        {
            StartPoint = new Point(0, canvas.Height),
            IsClosed = false
        };

        yFigure.Segments.Add(new LineSegment { Point = new Point(0, 0) });
        yGeometry.Figures.Add(yFigure);
        yAxis.Data = yGeometry;

        canvas.Children.Add(xAxis);
        canvas.Children.Add(yAxis);
        // Dibujar etiquetas en el eje horizontal (X)
        for (int i = 0; i < dates.Count(); i++)
        {
            var textBlock = new TextBlock
            {
                Text = dates.ElementAt(i),
                TextAlignment = TextAlignment.Center,
                Width = width / dates.Count(),
                Margin = new Thickness(i * (width / dates.Count()), height + 5, 0, 0)
            };
            canvas.Children.Add(textBlock);
        }

        // Dibujar etiquetas en el eje vertical (Y)
        // Puedes personalizar el rango y los intervalos según tus necesidades
        double minValue = 0;
        double maxValue = 100; // Ajusta esto según tus datos
        double interval = 20;

        for (double value = minValue; value <= maxValue; value += interval)
        {
            var textBlock = new TextBlock
            {
                Text = value.ToString(),
                TextAlignment = TextAlignment.Right,
                Margin = new Thickness(-40, height - (value / maxValue) * height, 0, 0)
            };
            canvas.Children.Add(textBlock);
        }
    }

    private void DibujarLineas(Canvas canvas, IEnumerable<string> dates, IEnumerable<double> values, Color color)
    {
        var paint = new SolidColorBrush(color);
        var points = ObtenerPuntos(dates, values, canvas.Width, canvas.Height).ToList();

        var path = new Path
        {
            Stroke = paint,
            StrokeThickness = 2
        };

        var geometry = new PathGeometry();

        var figure = new PathFigure
        {
            StartPoint = new Point(0, canvas.Height - points[0].Y),
            IsClosed = false
        };

        foreach (var point in points)
        {
            figure.Segments.Add(new LineSegment { Point = new Point(point.X, canvas.Height - point.Y) });
        }

        geometry.Figures.Add(figure);
        path.Data = geometry;

        canvas.Children.Add(path);

    }

    private IEnumerable<Point> ObtenerPuntos(IEnumerable<string> dates, IEnumerable<double> values, double width, double height)
    {
        var points = new List<Point>();
        var count = 0;

        foreach (var value in values)
        {
            var x = count * (width / (dates.Count() - 1));
            var y = value * (height / values.Max());

            points.Add(new Point(x, y));
            count++;
        }

        return points;
    }

    private IEnumerable<double> EscalarValores(IEnumerable<double> values, double maxHeight)
    {
        var max = values.Max();
        return values.Select(v => (v / max) * maxHeight);
    }
}


