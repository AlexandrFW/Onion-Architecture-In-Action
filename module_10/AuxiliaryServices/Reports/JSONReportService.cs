using Domain.Interfaces.Services;
using AuxiliaryServices.Tools;
using System.Collections.Generic;

namespace AuxiliaryServices.Reports
{
    internal class JSONReportService : IReportService
    {
        public string GetReport<T>(IEnumerable<T> serializedCollection)
        {
            if (serializedCollection is not null)
                return JSONSerializer.JSONSerialize(serializedCollection);

            return string.Empty;
        }
    }
}