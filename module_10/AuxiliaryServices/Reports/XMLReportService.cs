using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace AuxiliaryServices.Reports
{
    internal class XMLReportService : IReportService
    {
        public string GetReport<T>(IEnumerable<T> serializedCollection)
        {
            if (serializedCollection is null)
            {
                return string.Empty;
            }

            var xml = string.Empty;

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

            return xml;
        }
    }
}