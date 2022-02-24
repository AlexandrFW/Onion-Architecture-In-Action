using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace AuxiliaryServices.Tools
{
    internal static class JSONSerializer
    {
        public static T JSONDeserialize<T>(string json_string) 
        {
            T? deserializedObject = JsonSerializer.Deserialize<T>(json_string);

            return deserializedObject;
        }

        public static string JSONSerialize<T>(IEnumerable<T> serializedCollection)
        {
            var serializedObject = JsonSerializer.Serialize(serializedCollection);

            return serializedObject;
        }

        public static T JSONGetSection<T>(IConfigurationSection confSection)
        {
            T sectionValue = confSection.Get<T>();

            return sectionValue;
        }
    }
}