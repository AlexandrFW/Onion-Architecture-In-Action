using Domain.Interfaces.Services;
using AuxiliaryServices.Tools;

namespace AuxiliaryServices.Reports
{
    public class JSONReport : IReportService
    {
        public string GetReport<T>(IEnumerable<T> serializedCollection)
        {
            if (serializedCollection is not null)
                return JSONSerializer.JSONSerialize(serializedCollection);

            return string.Empty;
        }
    }
}