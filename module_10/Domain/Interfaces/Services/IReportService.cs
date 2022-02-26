using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IReportService
    {
        public string GetReport<T>(IEnumerable<T> serializedCollection);
    }
}