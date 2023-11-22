using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace medidas.Core;

public class GuardarMedidas
{
   public void MedidasToXml()
    {
        try{
            double peso = Convert.ToDouble(pesoTextBox.Text);
            double circunferencia = Convert.ToDouble(circunferenciaTextBox.Text);
            string notas = Convert.ToDouble(notasTextBox.Text);

            Medidas nuevaMedida = new Medidas(peso, circunferencia, notas);

            List<Medidas> listaMedidas = SacarMedidas();

            listaMedidas.Add(nuevaMedida);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Medidas>));

            using (TextWriter writer = new StreamWriter("medidas.xml")){
                serializer.Serialize(writer, listaMedidas);
            }

        }catch (Exception ex){
            Console.WriteLine($"Error al crear el archivo XML: {ex.Message}");
        }
    }

   private List<Medidas> XmlToMedidas(){
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
}
}
