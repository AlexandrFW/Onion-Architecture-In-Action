using Domain.ServiceTools;

namespace Domain.Interfaces.Services
{
    public interface IReportApiService
    {
        public string GetReport(ReportFilterCriteria reportCreteria);
    }
}