using Domain.Interfaces.Services;
using System.Xml;
using System.Xml.Serialization;

namespace AuxiliaryServices.Reports
{
    public class XMLReport : IReportService
    {
        public string GetReport<T>(IEnumerable<T> serializedCollection)
        {
            var xml = string.Empty;

            if (serializedCollection is not null)
            {
                serializedCollection = serializedCollection.ToList();

                using (var stringWriter = new StringWriter())
                {
                    var serializerXML = new XmlSerializer(serializedCollection.GetType());
                    using (var writer = XmlWriter.Create(stringWriter))
                    {
                        serializerXML.Serialize(writer, serializedCollection);
                        xml = stringWriter.ToString();
                    }
                }
            }

            return xml;
        }
    }
}