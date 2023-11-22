using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using medidas.Core;

namespace medidas.Core;

public class GuardarMedidas
{
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

        }catch (Exception ex){
        }
    }
}
}
