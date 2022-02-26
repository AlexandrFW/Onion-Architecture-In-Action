using Domain.Interfaces.Services;

namespace AuxiliaryServices.Reports
{
    public class ReportStrategyFactory : IReportStrategyFactory
    {
        public IReportService GetConcreteReportService(string format)
        {
            switch (format.ToLower())
            {
                case "xml":
                    return new XMLReportService();

                case "json":
                    return new JSONReportService();

                default:
                    return null;
            }            
        }
    }
}