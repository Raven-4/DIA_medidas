using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using medidas.Core;

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

    private List<Medidas> SacarMedidas(){
        try
        {
            string rutaArchivoXml = "medidas.xml";

            if (File.Exists(rutaArchivoXml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Medidas>));

                using (FileStream fileStream = new FileStream(rutaArchivoXml, FileMode.Open))
                {
                    return (List<Medidas>)serializer.Deserialize(fileStream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar la lista de medidas desde el archivo XML: {ex.Message}");
        }

        return new List<Medidas>();
    }
    }
    
    private void CrearGrafico()
    {
       //Meter medidas en grafico
    }

}
